import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/models/product.model';
import { ProductType } from 'src/app/models/productType.model';
import { ProductTypesService } from 'src/app/services/product-types.service';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css']
})
export class ProductsListComponent implements OnInit {

  products: Product[] = [];
  displayedProducts: Product[] = [];
  productTypes: ProductType[] = [];
  selectedType = '';
  constructor(private prodcutService: ProductsService, private prodcutTypeService: ProductTypesService) {

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

    this.fetchData();

  }

  fetchData() {
    this.prodcutService.getAllProducts()
      .subscribe({
        next: (products) => {
          this.products = products;
          this.displayedProducts = products;
        },
        error: (response) => {
          console.log(response);
        }
      });
  }

  updateTypeSelector(e) {
    this.selectedType = e.target.value;
    if (this.selectedType === "default") {
      this.displayedProducts = this.products.filter((product) => {
        return true;
      });
    }
    else {
      this.displayedProducts = this.products.filter((product) => {
        return product.type === this.selectedType;
      });
    }
  }

  deleteProduct(id: number) {
    this.prodcutService.deleteProduct(id)
      .subscribe({
        next: (response) => {
          this.fetchData();
        }
      });
  }

  confirmation(name: string,id: number) {
    if(confirm("Are you sure to delete product named: " + name)) {
      this.deleteProduct(id);
    }
  }

}
