// The application will create a renderer using WebGL, if possible,
// with a fallback to a canvas render. It will also setup the ticker
// and the root stage PIXI.Container
const app = new PIXI.Application();

document.documentElement.appendChild(app.view);

// load the texture we need
app.loader.add('ghost', "Step2.png").load((loader, resources) => {
    // This creates a texture from a 'bunny.png' image
    const ghost = new PIXI.Sprite(resources.ghost.texture);

// Setup the position of the bunny
ghost.x = app.renderer.width / 2;
ghost.y = app.renderer.height / 2;

// Rotate around the center
ghost.anchor.x = 0.5;
ghost.anchor.y = 0.5;

// Add the bunny to the scene we are building
app.stage.addChild(ghost);

// Listen for frame updates
app.ticker.add(() => {
    // each frame we spin the bunny around a bit
    ghost.rotation += 0.05;
});
});