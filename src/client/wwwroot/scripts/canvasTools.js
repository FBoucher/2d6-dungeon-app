
var canvas;
var context;
var vw,vh;
let cubeSize = 30;

// resize the canvas to fill the browser window
window.addEventListener('resize', onResize, false);
function onResize() {
  canvas = document.getElementById('dotCanvas');
  context = canvas.getContext('2d');

  vw = canvas.width;
  vh = canvas.height;

  resizeCanvas();
}

function resizeCanvas() {
  // Get the DPR and size of the canvas
  const dpr = window.devicePixelRatio;
  const rect = canvas.getBoundingClientRect();

  // Set the "actual" size of the canvas
  canvas.width = rect.width * dpr;
  canvas.height = rect.height * dpr;

  // Scale the context to ensure correct drawing operations
  context.scale(dpr, dpr);

  // Set the "drawn" size of the canvas
  canvas.style.width = `${rect.width}px`;
  canvas.style.height = `${rect.height}px`;
  drawDots();
}
// dots
function drawDots() {

  var r = 1,
      cw = cubeSize,
      ch = cubeSize;
  
  for (var x = 0; x < vw; x+=cw) {
    for (var y = 0; y < vh; y+=ch) {
        context.fillStyle = '#777777';   
        context.fillRect(x-r/2,y-r/2,r,r);
      }
  }
}

function DrawRoom(posX, posY, width, height){

  posX = posX * cubeSize;
  posY = posY * cubeSize;
  width = width * cubeSize;
  height = height * cubeSize;

  context.fillStyle = '#000000'; 
  context.fillRect(posX, posY, width, height);
  context.stroke();
  context.fillStyle = '#ffffff';
  context.fillRect(posX+1, posY+1, width-2, height-2);
  context.stroke();
}

function DrawDoor(posX, posY, orientation){

  if(orientation == "H"){
    let doorWith = 30; // one square
    let doorHeight = 10;
    posX = (posX - 1) * cubeSize;
    posY = (posY * cubeSize) - 5;

    context.fillStyle = '#000000'; 
    context.fillRect(posX, posY, doorWith, doorHeight);
    context.stroke();
    context.fillStyle = '#e6f2ff';
    context.fillRect(posX+1, posY+1, doorWith-2, doorHeight-2);
    context.stroke();
  }
  else{
    let doorWith = 10; 
    let doorHeight = 30;// one square
    posX = (posX * cubeSize) - 5;
    posY = (posY - 1) * cubeSize;

    context.fillStyle = '#000000'; 
    context.fillRect(posX, posY, doorWith, doorHeight);
    context.stroke();
    context.fillStyle = '#e6f2ff';
    context.fillRect(posX+1, posY+1, doorWith-2, doorHeight-2);
    context.stroke();
  }
}

function ClearMap(){
  context.fillStyle = '#Ece7d7';
  context.clearRect(0, 0, vw, vh);  
  drawDots()
}