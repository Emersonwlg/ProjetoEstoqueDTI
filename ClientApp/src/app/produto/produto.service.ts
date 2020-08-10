import { Injectable, Inject } from '@angular/core';
import { IProduto } from './produto';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class ProdutoService {
  private apiURL = this.baseUrl + "api/produtos" ;

  constructor( private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getProdutos() : Observable<IProduto[]>{
    return this.http.get<IProduto[]>(this.apiURL);
  } 

  getProduto(id : string) : Observable<IProduto>{
    return this.http.get<IProduto>(this.apiURL + '/' + id);
  } 

  createProduto(produto : IProduto) : Observable<IProduto> {
    return this.http.post<IProduto>(this.apiURL, produto);
  }

  updateProduto(produto : IProduto) : Observable<IProduto>{
    return this.http.put<IProduto>(this.apiURL + '/' + produto.id.toString(), produto);
  } 

  deleteProduto(id : string) : Observable<IProduto> {
    return this.http.delete<IProduto>(this.apiURL + '/' + id.toString());
  }
}