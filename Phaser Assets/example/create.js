function create () {
    /* ================================================== */

    this.add.image(400, 300, 'sky');

    platforms = this.physics.add.staticGroup({
        key: 'tile',
        repeat: 12,
        setXY: { x: 32, y: 568, stepX: 64 }
    });

    platforms.create(300, 500, 'tile');
    platforms.create(100, 540, 'tile');
    platforms.create(400, 440, 'tile');
    platforms.create(450, 400, 'tile');

    player = this.physics.add.sprite(100, 450, 'purple');
    player.setCollideWorldBounds(true);
    this.physics.add.collider(player, platforms);

    this.anims.create({
        key: 'left',
        frames: this.anims.generateFrameNumbers('purple', { start: 0, end: 3 }),
        frameRate: 10,
        repeat: -1
    });

    this.anims.create({
        key: 'turn',
        frames: [ { key: 'purple', frame: 4 } ],
        frameRate: 20
    });

    this.anims.create({
        key: 'right',
        frames: this.anims.generateFrameNumbers('purple', { start: 5, end: 8 }),
        frameRate: 10,
        repeat: -1
    });

    input = this.input.keyboard.createCursorKeys();
    
    /* ================================================== */
}