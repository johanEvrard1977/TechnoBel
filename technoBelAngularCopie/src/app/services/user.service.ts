import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../interfaces/user';
import { finalize } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  users$ : BehaviorSubject<User[]> = new BehaviorSubject<User[]>([]);

  constructor(private http: HttpClient) {
    this.refresh();
   }

  refresh()
  {
    return this.http.get<User[]>(environment.api_url + 'api/user')
      .subscribe(data => this.users$.next(data));
  }

  getById(id: number) {
    return this.http.get<User>(environment.api_url + 'api/user/' + id)
  }

  postUser(user:User)
  {
    return this.http.post<User>(environment.api_url + 'api/user/register/', user)
    .pipe(finalize(() =>this.refresh()));
  }

  updateUser(user:User)
  {
    return this.http.put<void>(environment.api_url + 'api/user/'+user.id, user)
    .pipe(finalize(() =>this.refresh()));
  }

  delete(id:number)
  {
    return this.http.delete<void>(environment.api_url + 'api/User/'+ id)
    .pipe(finalize(() =>this.refresh()));
  }

  testEmail(email:string)
  {
    return this.http.get<boolean>(environment.api_url + 'api/user/available/' + email)
  }
}
