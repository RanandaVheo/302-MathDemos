

void setup()
{
size(800, 600);
stroke(150, 0, 255);

}

void draw()
{
  background(64);
  
  float time = millis()/1000.0;
  
  float t = (sin(time*2) * 9) + 11; // sin = -1 to 1, we want range to be 2 to 20
  strokeWeight(t);
  
  ellipse(width/2, height/2, 400, 400);

}
