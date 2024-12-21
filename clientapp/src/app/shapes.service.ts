import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { Shape } from './shape.model';

@Injectable({
  providedIn: 'root'
})
export class ShapesService {
  private apiUrl = 'https://localhost:7210/api/Shapes';
  constructor(private http: HttpClient) {}

  getShapes(): Observable<Shape[]> {
    return this.http.get<any>(this.apiUrl).pipe(
      map((response: any) => {
        // Vérifie si la réponse contient $values
        return response.$values || []; // Retourne les valeurs ou un tableau vide
      })
    );
  }
}
