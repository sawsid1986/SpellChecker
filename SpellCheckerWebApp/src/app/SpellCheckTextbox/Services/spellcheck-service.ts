import { Injectable } from "@angular/core";
import { Observable, of } from "rxjs";
import { HttpClient } from "@angular/common/http";
import { catchError } from 'rxjs/operators'

@Injectable()
export class SpellCheckService {

  constructor(private http: HttpClient) {

  }

  getSuggestions(word): Observable<string[]> {
    return this.http.get<string[]>('http://localhost:59185/api/suggestions/' + word)
      .pipe(catchError(this.handleError<string[]>('getSuggestions', [])))
  }
  isCorrect(word: string): Observable<boolean> {
    return this.http.get<boolean>('http://localhost:59185/api/validate/' + word)
      .pipe(catchError(this.handleError<boolean>('isCorrect', false)))
  }

  private handleError<T>(opration = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      return of(result as T)
    }
  }
}
