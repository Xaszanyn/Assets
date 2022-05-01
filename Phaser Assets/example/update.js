function update () {
    /* ================================================== */

    if (input.left.isDown)
    {
        player.setVelocityX(-300);

        player.anims.play('left', true);
    }
    else if (input.right.isDown)
    {
        player.setVelocityX(300);

        player.anims.play('right', true);
    }
    else
    {
        player.setVelocityX(0);

        player.anims.play('turn');
    }

    if (input.up.isDown && player.body.touching.down)
    {
        player.setVelocityY(-1000);
    }

    /* ================================================== */
}