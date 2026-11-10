# MG6
1) A for loop completes all its iterations before the Update() method finishes. It does not run one iteration per frame. If the loop takes too long, it can make the game lag or freeze because it blocks the current frame.
2) The player's collider is disabled whenever the cat moves upward. This allows the cat to jump through platforms, but it can also pass through the ground or other objects. This happens because the code disables the entire collider instead of only ignoring platform collisions.

