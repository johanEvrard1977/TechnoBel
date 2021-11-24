import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { finalize } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Statut } from '../interfaces/statut';

@Injectable({
  providedIn: 'root'
})
export class StatutService {

  statuts$ : BehaviorSubject<Statut[]> = new BehaviorSubject<Statut[]>([]);

  constructor(private http: HttpClient) {
    this.refresh();
   }

  refresh()
  {
    return this.http.get<Statut[]>(environment.api_url + 'api/statut')
      .subscribe(data => this.statuts$.next(data));
  }

  getById(id: number) {
    return this.http.get<Statut>(environment.api_url + 'api/statut/' + id)
  }

  post(statut:Statut)
  {
    return this.http.post<Statut>(environment.api_url + 'api/statut/', statut)
    .pipe(finalize(() =>this.refresh()));
  }

  update(statut:Statut)
  {
    return this.http.put<void>(environment.api_url + 'api/statut/'+statut.id, statut)
    .pipe(finalize(() =>this.refresh()));
  }

  delete(id:number)
  {
    return this.http.delete<void>(environment.api_url + 'api/statut/'+ id)
    .pipe(finalize(() =>this.refresh()));
  }
}
