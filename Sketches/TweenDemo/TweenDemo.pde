
float xStart = 20;
float xEnd = 780;

float timeTotal = 5;
float timeCurrent = 0;

float timeS = 0;
float timePrev = 0;

void setup()
{
  size(800, 500);
}

void draw()
{
  background(64);

  timeS = millis()/1000.0;
  float dt = timeS - timePrev;
  timePrev = timeS;
  
  timeCurrent += dt;

  float p = timeCurrent / timeTotal;
  p = constrain(p, 0, 1); //clamp
  
  p = p * p * (3 - 2 * p);

  float x = lerp(xStart, xEnd, p);

  ellipse(x, height/2, 30, 30);
}

void mousePressed()
{
  timeCurrent = 0;
}
