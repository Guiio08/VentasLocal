import { Injectable } from '@angular/core';
import { AngularFirestore, AngularFirestoreCollection } from '@angular/fire/compat/firestore';
import { MessageI } from '../models/message.interface';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'

})
export class DataDbService {

  private APIUrl="https://localhost:44309/api";

  constructor(private http: HttpClient) {   }

  getClientesList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/clientes');
  } 

  getColorUniformes():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/colorUniformes')
  }

  getModelos():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/modelos')
  }
}
