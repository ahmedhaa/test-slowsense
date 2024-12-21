import { Component, OnInit } from '@angular/core';
import { ShapesService } from '../shapes.service';
import { Shape } from '../shape.model';

@Component({
  selector: 'app-shapes',
  templateUrl: './shapes.component.html',
  styleUrls: ['./shapes.component.css']
})
export class ShapesComponent implements OnInit {
  shapes: Shape[] = [];

  constructor(private shapesService: ShapesService) {}

  ngOnInit(): void {
    this.shapesService.getShapes().subscribe((data) => {
      console.log(data);
      this.shapes = data;
    });
  }

  showPopup(text: string): void {
    if (text) {
      alert(text); // Affiche le texte dans une popup
    } else {
      alert('Aucun texte disponible'); // Si aucun texte n'est fourni
    }
  }
  showText(shape: Shape) {
    alert(shape.text);
  }
  
}
