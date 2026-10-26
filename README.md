# https://youtu.be/67pBql63iaU

# lab9


object pool

Bullets are made 25 at startup to avoid creating and destroying them shot per shot. The object pool is what holds all 25, turns them on and off, and collects them after they have served their purpose.



Builder

Every target has a few variables too many for constructing them for many instances, ITargetBuilder is the blueprint to get around this. With ITargetBuilder with the listed parts, and TargetBuilder making the Targets themselves from the prefab and assigning the arguments. TargetDirector has the preset Buildables, and TargetSpawner gets a Target from the Director without the "blueprint" to build it on its own.



Observer
Target is the subject. On hit the target has an event that throws its point value. Scoremanager is the catch, the observer, that sees the event fire and adds to the score. Scoremanager also has an event to fire when the score changes so that scoreUI can be updated when it sees the event fire.

