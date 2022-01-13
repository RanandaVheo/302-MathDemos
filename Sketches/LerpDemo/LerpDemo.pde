// Lerp = Linear Interpolation



void setup()
{
  size(500, 500);
}


void draw()
{
  background(128);
  
  // calc the stroke weight
  float p2 = mouseY / (float)height;
  float w = lerp(1, 50, p2);
  
  //calc the percent
  float p = mouseX / (float)width;
  
  // calc the diameter
  float d = lerp(50, 500, p);
  
  strokeWeight(w);
  ellipse(width/2, height/2, d, d);
}
