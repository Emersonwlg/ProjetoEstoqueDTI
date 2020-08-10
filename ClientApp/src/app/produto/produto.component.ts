import { Component, OnInit } from '@angular/core';
import { IProduto } from './produto';
import { ProdutoService } from './produto.service';

@Component({
  selector: 'app-produto',
  templateUrl: './produto.component.html',
  styleUrls: ['./produto.component.css']
})
export class ProdutoComponent implements OnInit {

  //produtos : <lista produto>
  produtos : IProduto[];

  constructor(private produtoService :  ProdutoService) { }

  ngOnInit() {
        this.carregarDados();
  }

  delete(produto : IProduto) {
    this.produtoService.deleteProduto(produto.id.toString())
    .subscribe( produto => this.carregarDados(),
    error => console.error(error));
  }

  carregarDados() {
    this.produtoService.getProdutos()
    .subscribe(produtoWebAPI => this.produtos = produtoWebAPI ),
     error => console.error(error);
  }
}
