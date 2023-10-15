function getDocumentWidth() {
  return Math.max(document.documentElement.clientWidth, window.innerWidth || 0);
};

function getDocumentHeight() {
  return Math.max(document.documentElement.clientHeight, window.innerHeight || 0)
};


var canvas;
var context;
var vw,vh;

// resize the canvas to fill the browser window
window.addEventListener('resize', onResize, false);
function onResize() {
  canvas = document.getElementById('dotCanvas');
  context = canvas.getContext('2d');

  //vw = getDocumentWidth();
  //vh = getDocumentHeight();

  vw = canvas.width;
  vh = canvas.height;

  resizeCanvas();
}

function resizeCanvas() {
  //canvas.width = vw;
  //canvas.height = vh;
  drawDots();
}
// dots
function drawDots() {

  var r = 0.5,
      cw = 10,
      ch = 10;
  
  for (var x = 0; x < vw; x+=cw) {
    for (var y = 0; y < vh; y+=ch) {
        context.fillStyle = '#777777';   
        context.fillRect(x-r/2,y-r/2,r,r);
      }
  }
}

function DrawRoom(posX, posY, width, height){
  context.fillStyle = '#000000'; 
  context.fillRect(posX, posY, width, height);
  context.stroke();
  context.fillStyle = '#Ece7d7';
  context.fillRect(posX+1, posY+1, width-2, height-2);
  context.stroke();
}

function ClearMap(){
  context.fillStyle = '#ffffff';
  context.clearRect(0, 0, vw, vh);  
  drawDots()
}