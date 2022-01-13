
// 3 circles' x position
float x1, x2, x3;

// circle #2 velocity
float v2;


void setup()
{
  size(500, 500, P2D);
  frameRate(60);
}


void draw()
{
  background(0);
  
  //LINEAR MOVEMENT
  if(x1 < mouseX)
  {
    x1 += 5;
    if(x1 > mouseX) x1 = mouseX;
  }
  else 
  {
    x1 -= 5;
    if(x1 < mouseX) x1 = mouseX;
  }
  
  //physics on circle 2
  if(x2 < mouseX) v2 ++;
  else v2 --;
  v2 *= .95;
  x2 += v2;
  
  //damping: each tick, move 50% to the target
  x3 += (mouseX - x3) * .1; //10% like a lerp, finding 10% of the way to mouseX from x3 circle
  // same as writing x3 = lerp(x3, mouseX, .1);
  
  ellipse(x1, height * 1/4, 25, 25);
  ellipse(x2, height * 2/4, 25, 25);
  ellipse(x3, height * 3/4, 25, 25);
}
