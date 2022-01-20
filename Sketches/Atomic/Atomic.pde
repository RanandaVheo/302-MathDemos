// Animate 3 electrons orbiting around a nucleus.
// Each electron should follow a path and match
// colors with its respective path.

// Don't use rotate()
// Use vectors and trigonometry

float xB, xR, xG, yB, yR, yG;
float timeA = 0.0;

void setup(){
  size(400, 400);
}
void draw(){
  
  drawBackground();
  
  ///////////////// START YOUR CODE HERE:
  
  timeA++;
  noStroke();
  
   // Red Electron
  fill(255, 100, 100);
  xR = map(cos(radians(timeA)), -1, 1, 50, 350);
  yR = map(sin(radians(timeA)), -1, 1, 150, 250);
  
  ellipse(xR, yR, 15, 15);  
  
  // Green Electron
  fill(100, 255, 100);
  xG = map(cos(radians(timeA)), -1, 1, 50, 350);
  yG = map(sin(radians(timeA)), -1, 1, 50, 350);
  
  ellipse(xG, yG, 15, 15);
  
  // Blue Electron
  fill(100, 100, 255);
  xB = map(cos(radians(timeA)), -1, 1, 50, 350);
  yB = map(sin(radians(timeA)), -1, 1, 50, 350);
  
  ellipse(xB * sin(2*PI/3), yB * cos(2*PI/3), 15, 15);
  println(xB * sin(2*PI/3) + ", " + yB * cos(2*PI/3));
  
  ///////////////// END YOUR CODE HERE
  
}
void drawBackground(){
  background(0);
  noStroke();
  fill(255);
  ellipse(200,200,50,50);
  noFill();
  strokeWeight(5);
  
  pushMatrix();
  translate(200,200);
  stroke(255,100,100);
  ellipse(0,0,300,100);
  popMatrix();
  
  pushMatrix();
  translate(200,200);
  rotate(PI/1.5);
  stroke(100,255,100);
  ellipse(0,0,300,100);
  popMatrix();
  
  pushMatrix();
  translate(200,200);
  rotate(2*PI/1.5);
  stroke(100,100,255);
  ellipse(0,0,300,100);
  popMatrix();
}
