import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { finalize } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Hobby } from '../interfaces/hobby';

@Injectable({
  providedIn: 'root'
})
export class HobbyService {

  hobbies$ : BehaviorSubject<Hobby[]> = new BehaviorSubject<Hobby[]>([]);

  constructor(private http: HttpClient) {
    this.refresh();
   }

  refresh()
  {
    return this.http.get<Hobby[]>(environment.api_url + 'api/hobby')
      .subscribe(data => this.hobbies$.next(data));
  }

  getById(id: number) {
    return this.http.get<Hobby>(environment.api_url + 'api/hobby/' + id)
  }

  post(hobby:Hobby)
  {
    return this.http.post<Hobby>(environment.api_url + 'api/hobby/', hobby)
    .pipe(finalize(() =>this.refresh()));
  }

  update(hobby:Hobby)
  {
    return this.http.put<void>(environment.api_url + 'api/hobby/'+hobby.id, hobby)
    .pipe(finalize(() =>this.refresh()));
  }

  delete(id:number)
  {
    return this.http.delete<void>(environment.api_url + 'api/hobby/'+ id)
    .pipe(finalize(() =>this.refresh()));
  }
}
