/*
 * Gothicvania Town Demo Code
 * @copyright    2017 Ansimuz
 * Get more free assets and code like these at: www.pixelgameart.org
 * Visit my store for premium content at https://ansimuz.itch.io/
 * */

var game;
var player;
var folkIndex = 0;
var gameWidth = 430;
var gameHeight = 272;
var background;
var middleground;
var globalMap;
var townFolks;

window.onload = function () {
    game = new Phaser.Game(gameWidth, gameHeight, Phaser.AUTO, "");
    game.state.add('Boot', boot);
    game.state.add('Preload', preload);
    game.state.add('TitleScreen', titleScreen);
    game.state.add('PlayGame', playGame);
    //
    game.state.start('Boot');
}

var boot = function (game) {

}
boot.prototype = {
    preload: function () {
        this.game.load.image('loading', 'assets/sprites/loading.png');
    },
    create: function () {
        game.scale.pageAlignHorizontally = true;
        game.scale.pageAlignVertically = true;
        game.scale.scaleMode = Phaser.ScaleManager.SHOW_ALL;
        game.renderer.renderSession.roundPixels = true;
        this.game.state.start('Preload');
    }
}

var preload = function (game) {
};

preload.prototype = {
    preload: function () {
        var loadingBar = this.add.sprite(game.width / 2, game.height / 2, 'loading');
        loadingBar.anchor.setTo(0.5);
        game.load.setPreloadSprite(loadingBar);
        // load title screen
        game.load.image('title', 'assets/sprites/title-screen.png');
        game.load.image('enter', 'assets/sprites/press-enter-text.png');
        game.load.image('credits', 'assets/sprites/credits-text.png');
        game.load.image('instructions', 'assets/sprites/instructions.png');
        // environment
        game.load.image('background', 'assets/environment/background.png');
        game.load.image('middleground', 'assets/environment/middleground.png');
        // tileset
        game.load.image('tileset', 'assets/environment/tileset.png');
        game.load.tilemap('map', 'assets/maps/map.json', null, Phaser.Tilemap.TILED_JSON);
        // atlas sprite
        game.load.atlasJSONArray('atlas', 'assets/atlas/atlas.png', 'assets/atlas/atlas.json');
        game.load.atlasJSONArray('atlas-props', 'assets/atlas/atlas-props.png', 'assets/atlas/atlas-props.json');
        // audio
        game.load.audio('music', ['assets/sounds/rpg_village02__loop.ogg','assets/sounds/rpg_village02__loop.mp3']);
        game.load.audio('switch', ['assets/sounds/switch.ogg']);
    },
    create: function () {
        //this.game.state.start('PlayGame');
        this.game.state.start('TitleScreen');
    }
}

var titleScreen = function (game) {

};

titleScreen.prototype = {
    create: function () {
        background = game.add.tileSprite(0, 0, gameWidth, gameHeight, 'background');
        middleground = game.add.tileSprite(0, 0, gameWidth, gameHeight, 'middleground');
        //
        this.title = game.add.image(gameWidth / 2, 100, 'title');
        this.title.anchor.setTo(0.5);
        var credits = game.add.image(gameWidth / 2, game.height - 12, 'credits');
        credits.anchor.setTo(0.5);
        this.pressEnter = game.add.image(game.width / 2, game.height - 75, 'enter');
        this.pressEnter.anchor.setTo(0.5);

        game.time.events.loop(700, this.blinkText, this);

        var startKey = game.input.keyboard.addKey(Phaser.Keyboard.ENTER);
        startKey.onDown.add(this.startGame, this);

        this.state = 1;
    },

    blinkText: function () {
        if (this.pressEnter.alpha) {
            this.pressEnter.alpha = 0;
        } else {
            this.pressEnter.alpha = 1;
        }
    },
    update: function () {
        middleground.tilePosition.x -= 0.2;
    },
    startGame: function () {
        if (this.state == 1) {
            this.state = 2;
            this.title2 = game.add.image(game.width / 2, 40, 'instructions');
            this.title2.anchor.setTo(0.5, 0);
            this.title.destroy();
        } else {
            this.game.state.start('PlayGame');
        }
    }
}

var playGame = function (game) {
};
playGame.prototype = {

    create: function () {
        this.bindKeys();
        this.createBackgrounds();
        this.createTileMap();
        this.decorWorld();
        this.populate();

        var changeKey = game.input.keyboard.addKey(Phaser.Keyboard.SPACEBAR);

        changeKey.onDown.add(this.switchCharacter, this);
        // music
        this.music = game.add.audio('music');
        this.music.loop = true;
        this.music.play();
        //
        this.switchSound = game.add.audio('switch');

    },

    decorWorld: function () {
        this.addProp(25 * 16, 3 * 16 + 2, 'house-a');
        this.addProp(35 * 16, -10, 'house-b');
        this.addProp(48 * 16, 3 * 16 + 2, 'house-a');
        //
        this.addProp(1 * 16 - 32, 10*  16 + 7 , 'crate-stack');
        this.addProp(76 * 16 - 32, 10*  16 + 7 , 'crate-stack');
        //
        this.addProp(1 * 16 ,  8 *  16   , 'street-lamp');
        this.addProp(26 * 16 ,  8 *  16   , 'street-lamp');
        this.addProp(60 * 16 ,  8 *  16   , 'street-lamp');
        //
        this.addProp(17 * 16 ,  11 *  16 - 3   , 'well');
        //
        this.addProp(42 * 16 - 5 ,  10 *  16    , 'sign');
        this.addProp(3 * 16   ,  13 *  16    , 'barrel');
        this.addProp(5 * 16   ,  13 *  16    , 'barrel');
        this.addProp(70 * 16   ,  13 *  16    , 'barrel');
        this.addProp(71 * 16 + 8  ,  13 *  16    , 'barrel');

        this.addProp(54 * 16 + 8  ,  10 *  16    , 'wagon');
        this.addProp(23 * 16   ,  13 *  16 - 6   , 'crate');
    },

    addProp: function (x, y, item) {
        game.add.image(x, y, 'atlas-props', item);
    },

    bindKeys: function () {
        this.wasd = {
            left: game.input.keyboard.addKey(Phaser.Keyboard.LEFT),
            right: game.input.keyboard.addKey(Phaser.Keyboard.RIGHT)
        }
        game.input.keyboard.addKeyCapture([
            Phaser.Keyboard.LEFT,
            Phaser.Keyboard.RIGHT,
            Phaser.Keyboard.SPACEBAR
        ]);
    },

    createBackgrounds: function () {
        background = game.add.tileSprite(0, 0, gameWidth, gameHeight, 'background');
        middleground = game.add.tileSprite(0, 0, gameWidth, gameHeight, 'middleground');
        background.fixedToCamera = true;
        middleground.fixedToCamera = true;
    },

    createTileMap: function () {
        // tiles
        globalMap = game.add.tilemap('map');
        globalMap.addTilesetImage('tileset');
        this.layer = globalMap.createLayer('Tile Layer 1');
        this.layer.resizeWorld();

        // collisions
        globalMap.setCollision([1, 354, 356, 203, 204, 206, 208, 209, 270, 271, 272]);

    },

    populate: function () {
        //groups
        townFolks = game.add.group();
        townFolks.enableBody = true;

        this.addBearded(5, 13);
        this.addHatMan(18, 6);
        this.addOldman(35, 13);
        this.addWoman(60, 13);

        player = townFolks.getAt(folkIndex);
        game.camera.follow(player, Phaser.Camera.FOLLOW_PLATFORMER);

    },

    addBearded: function (x, y) {
        var temp = new FolkBeard(game, x, y);

        game.add.existing(temp);
        townFolks.add(temp);

    },

    addHatMan: function (x, y) {
        var temp = new FolkHat(game, x, y);
        game.add.existing(temp);
        townFolks.add(temp);
    },

    addOldman: function (x, y) {
        var temp = new FolkOld(game, x, y);
        game.add.existing(temp);
        townFolks.add(temp);
    },

    addWoman: function (x, y) {
        var temp = new FolkWoman(game, x, y);
        game.add.existing(temp);
        townFolks.add(temp);
    },

    update: function () {
        game.physics.arcade.collide(townFolks, this.layer);

        this.controlCharacter();
        this.parallaxBackground();

        //this.debugGame();

    },

    parallaxBackground: function () {
        middleground.tilePosition.x = this.layer.x * -0.5;
        background.tilePosition.x = this.layer.x * -0.2;
    },

    controlCharacter: function () {

        if (player) {

            var speed = 100;
            if (this.wasd.left.isDown) {
                player.body.velocity.x = -speed;
                player.scale.x = -1;
                player.animations.play('walk');
            } else if (this.wasd.right.isDown) {
                player.body.velocity.x = speed;
                player.scale.x = 1;
                player.animations.play('walk');
            } else {
                player.body.velocity.x = 0;
                player.animations.play('idle');
            }

        }

    },

    switchCharacter: function () {

        var total = townFolks.children.length;

        if (folkIndex >= total - 1) {
            folkIndex = 0;
        } else {

            folkIndex++;
        }

        player.body.velocity.x = 0;
        player.animations.play('idle');

        player = townFolks.getAt(folkIndex);
        game.camera.follow(player, Phaser.Camera.FOLLOW_PLATFORMER);

        this.switchSound.play();
    },

    debugGame: function () {
        townFolks.forEachAlive(this.renderGroup, this);

    },

    renderGroup: function (member) {
        game.debug.body(member);

    }

}

// townfolk objects

FolkBeard = function (game, x, y) {

    x *= 16;
    y *= 16;
    Phaser.Sprite.call(this, game, x, y, 'atlas', 'bearded-idle-1');
    var f = 'bearded-idle-4';
    this.animations.add('idle', ['bearded-idle-1', 'bearded-idle-2', 'bearded-idle-3', f, f, f, f, f, f, f, f, f, f, f, f], 10, true);
    this.animations.add('walk', Phaser.Animation.generateFrameNames('bearded-walk-', 1, 6, '', 0), 10, true);
    this.animations.play('idle');
    this.anchor.setTo(0.5);
    game.physics.arcade.enable(this);
    this.body.gravity.y = 500;

}
FolkBeard.prototype = Object.create(Phaser.Sprite.prototype);
FolkBeard.prototype.constructor = FolkBeard;

//

FolkHat = function (game, x, y) {
    x *= 16;
    y *= 16;
    Phaser.Sprite.call(this, game, x, y, 'atlas', 'hat-man-idle-1');
    this.animations.add('idle', Phaser.Animation.generateFrameNames('hat-man-idle-', 1, 4, '', 0), 10, true);
    this.animations.add('walk', Phaser.Animation.generateFrameNames('hat-man-walk-', 1, 6, '', 0), 10, true);
    this.animations.play('idle');
    this.anchor.setTo(0.5);
    game.physics.arcade.enable(this);
    this.body.gravity.y = 500;

}
FolkHat.prototype = Object.create(Phaser.Sprite.prototype);
FolkHat.prototype.constructor = FolkHat;

//

FolkOld = function (game, x, y) {
    x *= 16;
    y *= 16;
    Phaser.Sprite.call(this, game, x, y, 'atlas', 'oldman-idle-1');
    var f = 'oldman-idle-8';
    this.animations.add('idle', ['oldman-idle-1', 'oldman-idle-2', 'oldman-idle-3', 'oldman-idle-4', 'oldman-idle-5', 'oldman-idle-6', 'oldman-idle-7', f, f, f, f, f, f, f, f, f, f, f, f, f, f, f, f, f, f, f, f, f, f, f, f, f, f, f, f, f, f, f, f, f, f, f, f, f, f, f, f, 'oldman-idle-6', 'oldman-idle-5', 'oldman-idle-4', 'oldman-idle-3'], 10, true);
    this.animations.add('walk', Phaser.Animation.generateFrameNames('oldman-walk-', 1, 12, '', 0), 10, true);
    this.animations.play('idle');
    this.anchor.setTo(0.5);
    game.physics.arcade.enable(this);
    this.body.gravity.y = 500;
}
FolkOld.prototype = Object.create(Phaser.Sprite.prototype);
FolkOld.prototype.constructor = FolkOld;

//

FolkWoman = function (game, x, y) {
    x *= 16;
    y *= 16;
    Phaser.Sprite.call(this, game, x, y, 'atlas', 'woman-idle-1');
    this.animations.add('idle', Phaser.Animation.generateFrameNames('woman-idle-', 1, 7, '', 0), 10, true);
    this.animations.add('walk', Phaser.Animation.generateFrameNames('woman-walk-', 1, 6, '', 0), 10, true);
    this.animations.play('idle');
    this.anchor.setTo(0.5);
    game.physics.arcade.enable(this);
    this.body.gravity.y = 500;
}
FolkWoman.prototype = Object.create(Phaser.Sprite.prototype);
FolkWoman.prototype.constructor = FolkWoman;
