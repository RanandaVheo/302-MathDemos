


float xStart = 20;
float xEnd = 780;

float timeTotal = 3;
float timeCurr = 0;
float timePrev;


void setup()
{
  size(800, 500);
}

void draw()
{
  background(64);

  timeCurr = millis()/1000.0;
  float dt = timeCurr - timePrev;
  timePrev = timeCurr;
  
  timeCurr += dt;

  float p = timeCurr / timeTotal;
  p = constrain(p, 0, 1); //clamp
  
  p = p * p * (3 - 2 * p);

  float x = lerp(xStart, xEnd, p);

  ellipse(x, height/2, 30, 30);
}



void mousePressed()
{
  timeCurr = 0;
  
  
}
