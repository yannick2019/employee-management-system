import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IOffice } from '../../models/interface/IOffice';

@Injectable({
  providedIn: 'root',
})
export class OfficeService {
  private apiUrl = 'http://localhost:5000/api/offices';
  private http = inject(HttpClient);

  constructor() {}

  getOffices(): Observable<IOffice[]> {
    return this.http.get<IOffice[]>(this.apiUrl);
  }
}
