// Animate 3 electrons orbiting around a nucleus.
// Each electron should follow a path and match
// colors with its respective path.

// Don't use rotate()
// Use vectors and trigonometry

void setup() {
  size(400, 400);
}
void draw() {

  drawBackground();

  ///////////////// START YOUR CODE HERE:

  noStroke();

  PVector red = FindOvalPos(0,0);
  PVector green = FindOvalPos(60, 1);
  PVector blue = FindOvalPos(-60, 2);

  // Red Electron
  fill(255, 100, 100);
  ellipse(red.x, red.y, 15, 15);  

  // Green Electron
  fill(100, 255, 100);
  ellipse(green.x, green.y, 15, 15);

  // Blue Electron
  fill(100, 100, 255);
  ellipse(blue.x, blue.y, 15, 15);
  
  ///////////////// END YOUR CODE HERE
}
PVector FindOvalPos(float rotateAmount, float time)
{
  float timeA = millis()/1000.0;

  //finds path on the oval
  float x = 150 * cos(timeA);
  float y = 50 * sin(timeA);

  //converts coordinates to polar
  float angle = atan2(y, x);
  float mag = sqrt(x*x + y*y);

  //rotates vector
  angle -= radians(rotateAmount);

  //convert back to cartesian
  x = mag * cos(angle);
  y = mag * sin(angle);

  //translate to center of screen
  x += width/2;
  y += height/2;

  return new PVector(x, y);
}


void drawBackground() {
  background(0);
  noStroke();
  fill(255);
  ellipse(200, 200, 50, 50);
  noFill();
  strokeWeight(5);

  pushMatrix();
  translate(200, 200);
  stroke(255, 100, 100);
  ellipse(0, 0, 300, 100);
  popMatrix();

  pushMatrix();
  translate(200, 200);
  rotate(PI/1.5);
  stroke(100, 255, 100);
  ellipse(0, 0, 300, 100);
  popMatrix();

  pushMatrix();
  translate(200, 200);
  rotate(2*PI/1.5);
  stroke(100, 100, 255);
  ellipse(0, 0, 300, 100);
  popMatrix();
}
