import { Component, OnInit } from '@angular/core';
import { DataDbService } from 'src/app/services/data-db.service';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-registro-ventas',
  templateUrl: './registro-ventas.component.html',
  styleUrls: ['./registro-ventas.component.css']
})
export class RegistroVentasComponent implements OnInit {


  listaColorUniformes: any[]=[];
  listaModelos: any[]=[];
  /* listFacturacion: any[]={

  }; */
  createFormGroup(){
    return new FormGroup({
      email : new FormControl(''),
      name : new FormControl(''),
      message : new FormControl('')
    })
  }

  form : FormGroup;

  constructor(private fb: FormBuilder,
    private _clientesServices:DataDbService,
    private _colorUniformes:DataDbService,
    private _modelos:DataDbService) {
   this.form = this.fb.group({
      nombreCliente:[''],
      telefono:[''],
      fechaPedido:[''],
      fechaEntrega:[''],
      cantidad:[''],
      genero:[''],
      modelo:[''],
      talla:[''],
      colorUniforme:[''],
      embone:[''],
      colorEmbone:['']
   })
   }

  ngOnInit(): void {
      this.obtenerClientes();
      this.obtenerColorUniformes();
      this.obtenerModelos();
  }

  obtenerClientes(){
    this._clientesServices.getClientesList().subscribe(data => {
      console.log(data);
    },error =>{
      console.log(error);
    })
  }

  obtenerColorUniformes(){
    this._colorUniformes.getColorUniformes().subscribe(data => {
      this.listaColorUniformes = data;
      console.log(data);
    },error =>{
      console.log(error);
    })
  }

  obtenerModelos(){
    this._modelos.getModelos().subscribe(data => {
      this.listaModelos = data;
      console.log(data);
    },error =>{
      console.log(error);
    })
  }

  crearPedido(){
    console.log(this.form);
  }
  /* onResetForm(){
    this.contactForm.reset();
  }

  onSaveForm(){
    this.dbData.saveMessage(this.contactForm.value);
  }
 */
}
