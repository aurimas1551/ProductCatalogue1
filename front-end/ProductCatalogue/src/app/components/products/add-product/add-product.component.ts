import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/models/product.model';
import { ProductType } from 'src/app/models/productType.model';
import { ProductTypesService } from 'src/app/services/product-types.service';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {

  productTypes: ProductType[] = [];
  selectedType = '';

  addProductRequest: Product = {
    id: 0,
    type: '',
    description: ''
  }
  constructor(private productService: ProductsService, private prodcutTypeService: ProductTypesService) {

  }

  ngOnInit(): void {
    this.prodcutTypeService.getAllProductTypes()
      .subscribe({
        next: (productTypes) => {
          this.productTypes = productTypes;
        },
        error: (response) => {
          console.log(response);
        }
      });

  }

  updateTypeSelector(e) {
    this.selectedType = e.target.value
  }

  addProduct() {
    if (this.addProductRequest.type.length == 0) {
      console.log("You must select a type");
    } else if (this.addProductRequest.description.trim().length == 0) {
      console.log("You must add description to your product");
    } else {
      this.productService.addProduct(this.addProductRequest)
        .subscribe({
          next: (product) => {
            console.log("Successfully added product");
            this.addProductRequest.id = 0;
            this.addProductRequest.type = '';
            this.addProductRequest.description = '';
          },
          error: (response) => {
            console.log(response);
          }
        });
    }
  }
}
