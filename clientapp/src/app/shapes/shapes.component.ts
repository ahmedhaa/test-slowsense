import { Component, OnInit } from '@angular/core';
import { ShapesService } from '../shapes.service';
import { Shape } from '../shape.model';
import { ApiResponse } from '../api-response.model';

@Component({
  selector: 'app-shapes',
  templateUrl: './shapes.component.html',
  styleUrls: ['./shapes.component.css']
})
export class ShapesComponent implements OnInit {
  shapes: Shape[] = [];

  constructor(private shapesService: ShapesService) {}

  ngOnInit(): void {
    this.shapesService.getShapes().subscribe((shapes: Shape[]) => {
      this.shapes = shapes.sort((a, b) => a.order - b.order); 
      console.log('Shapes:', this.shapes);
    });
  }

 
  

  showPopup(text: string): void {
    if (text) {
      alert(text); 
    } 
  }

 
}
