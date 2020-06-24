## Flocking and Predator Techniques in Video Games

"... and the thousands of fishes moved as a huge beast, piercing the water. They appeared united, inexorably bound to a common fate. How comes this unity?"
 --Anonymous, 17th century (from Shaw)

In my independent research, I have explored various artificial intelligence (AI) techniques and concepts. I will specifically be writing about what I have learned about flocking and predators in video games. As I have a mix of learning styles, I have applied what I have learned by building a test scene in unity to gain a practical understanding and retain what I have been researching. I will be discussing these concepts further in detail. Firstly, I would like to discuss a brief introduction to AI in video games


[live demo](https://vimeo.com/431711050)


![](1.PNG)

## AI in video games

The increasing innovations and “advances in 3D visualization and physics-based simulation technology” make it possible for game developers to “create compelling, visually immersive gaming environments” that were only dreamed of years ago.
Games we play nowa days have grown in sophistication as has the players expectations of the degree of emersion they may experience while playing.  Therefore embracing ways to incorporate more cutting-edge AI advancements into games will enhance immersive player experience which is very beneficial.
AI is not just a field for those who have committed their careers to it but is fundamentally used by most game developers in one way or another.
“In the broadest sense, most games incorporate some form of artificial intelligence (AI). For instance, developers have used AI for years to give seemingly intelligent life to countless game characters, from the ghosts in the classic arcade game Pac Man to the bots in the first-person shooter Unreal, and many others in between. The huge variety of game genres and game characters necessitates a rather broad interpretation as to what is considered game AI. Indeed, this is true of AI in more traditional scientific applications as well.” Bough and Seemann ,D,G. AI for Game Developers © 2020 O'Reilly Media, Inc.

## Defining AI

This is a widely discussed topic that has varying opinions about the measuring up of artificial intelligence against human intelligence and all the facets that that would include. Any AI that may “measure up” to human intellect would be considered strong AI. This  type of AI would be non-deterministic and is rarely used in game design “because if you have a neural network continually adapting and learning new behaviours there would be a good chance that something unexpected could happen which could break the game.

Falling under the category of weak AI or deterministic behaviour, video games include a broader range of behaviours that give or mimic intelligence. For the most part, game AI gives the illusion of intelligence which makes the player experience immersive and most importantly, exciting. This type of AI is favoured by game designers as it still ensures predictability but with the illusion of uncertainty by some impressive programming techniques.  

### Deterministic Versus Nondeterministic AI

### Deterministic

“Deterministic behaviour or performance is specified and predictable. There’s no uncertainty. An example of deterministic behaviour is a simple chasing algorithm. You can explicitly code a nonplayer character to move toward some target point by advancing along the x and y coordinate axes until the character’s x and y coordinates coincide with the target location.”

### Nondeterministic

“Nondeterministic behaviour is the opposite of deterministic behaviour. Behaviour has a degree of uncertainty and is somewhat unpredictable (the degree of uncertainty depends on the AI method employed and how well that method is understood). An example of nondeterministic behaviour is a nonplayer character learning to adapt to the fighting tactics of a player. Such learning could use a neural network, a Bayesian technique, or a genetic algorithm.”
With understanding the difference between deterministic and nondeterministic AI, my flocking and predator behaviour that I have built-in unity falls under the deterministic AI. Based on a physical science concept often used in modelling motion, potential function based movements is a technique that handles chasing, evading swarming, and collision avoidance simultaneously
D. R. BRILLINGER, H. K. PREISLER, A. A. AGER, J. G. KIE

## Flocking

To portray realistic  behaviours in video games, “nonplayer characters must move in cohesive groups rather than independently.” Thus,  portraying the illusion that the nonplayer characters have a purpose. Properties in the flock such as collision, direction and force (speed) propagate from one member to the next member in the flock, giving it a unified behaviour. If we had to create every single member independently and then put them into a flock it would be extremely labour intensive. Fortunately, flocking algorithms such as the one presented by Craig Reynolds in his 1987 SIGGRAPH paper, “Flocks, Herds, and Schools: Gives us an amazing foundation for group behaviours. Furthermore, it demonstrates that it doesn’t take “ a huge leap of faith to see that you could apply such flocking behaviour” to a variety of creatures even that of human characters.

[Reynolds, Craig W. (1987). "Flocks, herds, and schools: A distributed behavioral model". Proceedings of the 14th Annual Conference on Computer Graphics and Interactive Techniques]

[Craig Reynolds – Original 1986 Boids simulation]()


![](2.PNG)

Inspired by the monarch butterfly migration from Canada to Mexico I have used swarming butterflies in my unity game example.

[Monarch butterfly migration article](https://www.nationalgeographic.com/news/2017/10/monarch-butterfly-migration/)

[Monarch butterfly migration video](https://www.youtube.com/watch?v=lWOySU_hAz0)

![](2.PNG)

When discussing his simulated flocks Craig Reynolds coined the term boids.

“ All the boids can be moving in one direction at one moment, and then the next moment the tip of the flock formation can turn and the rest of the flock will follow as a wave of turning boids propagates through the flock. Reynolds’ implementation is leaderless in that no one boid actually leads the flock; in a sense they all sort of follow the group, which seems to have a mind of its own. The motion Reynolds’ flocking algorithm generated is quite impressive. Even more impressive is the fact that this behaviour is the result of three elegantly simple rules. These rules are summarized as follows:”

### Cohesion
“Have each member steer toward the average position of its neighbours.”
### Alignment
“Have each member align itself to the average heading of its neighbours.”
### Separation
“Have each member steer to avoid hitting its neighbours.”

These rules make it clear that the members of the flock need to be aware of each other and have the ability to direct their movement. Within each member’s immediate vicinity,  it knows the rough location, direction and separation from the other members in its territory.
You don’t have to worry about rotation when using particles which would make it easier to prototype however to build a more realistic version of what might be designed in a game,  I have used a butterfly prefab which allows me to take care of orientation. Including them rotating to face the direction they need to be going and turning away from obstacles that they need to be avoiding.

•	Turn to the average heading of the group
•	Turn to the average centre of the group
•	And avoid bumping into those around you

[Member visibility](https://www.oreilly.com/library/view/ai-for-game/0596005555/ch04.html)
![](4.PNG)

The above diagram shows how a member of the flock should be concerned with what is happening in its immediate vicinity

### My Unity Flocking Example

The example I have made involves simulating several members of butterflies that can move around in flocks or one big flock, depending on the values you change in the inspector via the flock manager. Applying the [bounds method](), the swarm is bound in a box. If they venture out of those borders, they are prompted to turn around being directed back to the center of the box, using a [slerp](). They may also be directed to turn away from an obstacle or predator employing a [reflection vector]().If they are not prompted to turn they will apply the swarm rules which I will be discussing further in detail below.

#### The FlockManager.cs  

Creates all the butterflies and informs them about the other butterflies in the swarm. To start, it simply creates an array of cubes (butterflies) and instantiates all the cube objects and puts them at a random position within the location of the flock managers fly limits using a neutral rotation.

For a cohesive swarm, it is better to use a large range as this will allow a member to see more of the group and direct themselves accordingly. Navigating around obstacles can also cause the swarm to break up. Thus, using a larger range will assist the members of the swarm re-grouping.

Some members may fragment if they lose sight of their neighbours as their neighbour could have been their link to the swarm. When they come within sight of a member again, they would re-join the swarm.

On the other hand, if you use a smaller range the swarm will start to fragment into smaller swarms as they lose sight and their link to the extended swarm.

**You can test this by changing the butterfly settings in the inspector via the flock manager**

#### Flock.cs

Attached to the butterfly prefab and linked to the FlockManager.cs, the Flock.cs applies the rules.

## Cohesion

To unify the swarm each member needs to direct themselves to the average position of its neighbours.

**The sum of all positions divided the number in the group**
 ![](5.PNG)
 [Average position and heading of neighbours]()

## Alignment

**Add all the headings of the individuals together and divide by the size of the group**

Alignment denotes that we want all the members in the swarm to generally head in the same direction. To satisfy this rule, I have the swarm following a goal that randomly updates it position within its bounds. There are also random speed ranges which adds to the illusion of natural behaviour for the swarm.

### Separation

If we reflect on the avoidance rule, we are trying to prevent the members from bumping into each other, “while at the same time enabling the members to get close to each other based on the alignment and cohesion rules” Therefore, we’ll enforce separation by requiring the members to direct themselves “away from any neighbour that is within view and within a prescribed minimum [separation distance”]()

[Neighbours and separation]()
![](6.PNG)
