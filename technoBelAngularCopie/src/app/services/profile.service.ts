import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { finalize } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Profile } from '../interfaces/profile';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {

  profiles$ : BehaviorSubject<Profile[]> = new BehaviorSubject<Profile[]>([]);

  constructor(private http: HttpClient) {
    this.refresh();
   }

  refresh()
  {
    return this.http.get<Profile[]>(environment.api_url + 'api/profile')
      .subscribe(data => this.profiles$.next(data));
  }

  getById(id: number) {
    return this.http.get<Profile>(environment.api_url + 'api/profile/' + id)
  }

  post(profile:Profile)
  {
    return this.http.post<Profile>(environment.api_url + 'api/profile/', profile)
    .pipe(finalize(() =>this.refresh()));
  }

  update(profile:Profile)
  {
    return this.http.put<void>(environment.api_url + 'api/profile/'+profile.id, profile)
    .pipe(finalize(() =>this.refresh()));
  }

  delete(id:number)
  {
    return this.http.delete<void>(environment.api_url + 'api/profile/'+ id)
    .pipe(finalize(() =>this.refresh()));
  }
}
