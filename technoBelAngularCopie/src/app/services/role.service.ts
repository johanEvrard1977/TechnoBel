import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { finalize } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Role } from '../interfaces/role';

@Injectable({
  providedIn: 'root'
})
export class RoleService {

  roles$ : BehaviorSubject<Role[]> = new BehaviorSubject<Role[]>([]);

  constructor(private http: HttpClient) {
    this.refresh();
   }

  refresh()
  {
    return this.http.get<Role[]>(environment.api_url + 'api/role')
      .subscribe(data => this.roles$.next(data));
  }

  getById(id: number) {
    return this.http.get<Role>(environment.api_url + 'api/role/' + id)
  }

  post(role:Role)
  {
    return this.http.post<Role>(environment.api_url + 'api/role/', role)
    .pipe(finalize(() =>this.refresh()));
  }

  update(role:Role)
  {
    return this.http.put<void>(environment.api_url + 'api/role/'+role.id, role)
    .pipe(finalize(() =>this.refresh()));
  }

  delete(id:number)
  {
    return this.http.delete<void>(environment.api_url + 'api/role/'+ id)
    .pipe(finalize(() =>this.refresh()));
  }
}
