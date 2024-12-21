export interface Shape {
    id: string;
    formsTypeId: number;
    positionX: number;
    positionY: number;
    width: number | null;
    height: number | null;
    text?: string;
    order: number;
    formsType?: {
      name: string; 
    };
  }
  