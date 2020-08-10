import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ProdutoService } from '../produto.service';
import { Router, ActivatedRoute } from '@angular/router';
import { IProduto } from '../produto';

@Component({
  selector: 'app-produto-form',
  templateUrl: './produto-form.component.html',
  styleUrls: ['./produto-form.component.css']
})
export class ProdutoFormComponent implements OnInit {

  constructor(private fb : FormBuilder, 
    private produtoService: ProdutoService, private router : Router , private activatedRoute : ActivatedRoute) { }

  formGroup : FormGroup; 
  modoEdicao : boolean = false;
  id : number;

  ngOnInit() {
     this.formGroup = this.fb.group ({
       nome : '',
       quantidade: '',
       valorunitario: ''
     });

    this.activatedRoute.params.subscribe(params=> {
        if(params["id"] == undefined ) {
          return;
        }

        this.modoEdicao = true;
        this.id = params["id"];

        this.produtoService.getProduto(this.id.toString())
        .subscribe( produtoWS => this.carregarFormulario(produtoWS),
          error => console.error(error));
    });
  } 

  carregarFormulario(produto : IProduto){
      this.formGroup.patchValue({
        nome : produto.nome,
        quantidade: produto.quantidade,
        valorunitario: produto.valorunitario
      });
  }


  save() {

    let produto : IProduto = Object.assign({}, this.formGroup.value);

    if(this.modoEdicao)   
    { //editar dados
        produto.id = this.id;
        this.produtoService.updateProduto(produto)
        .subscribe(produto=> this.OnSaveSucess()),
         error => console.error(error);
    }
    else
    {//incluir dados
         this.produtoService.createProduto(produto)
        .subscribe(produto=> this.OnSaveSucess()),
         error => console.error(error);
    }
  }

  OnSaveSucess(){
    this.router.navigate(["/produto"]);
  }

}
