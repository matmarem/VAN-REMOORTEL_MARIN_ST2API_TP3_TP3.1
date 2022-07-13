1)	What I found complicated in TP2 is mostly the connection to the API and the deserialization of JSON. 
In the end, it wasn't necessarily very complicated, it's just that we hadn't seen it before in class. 
Unfortunately there is not much to do... We have to connect to an API and process our raw data X)

2)	The SOLID principles are intended for object-oriented programming. 
S: The Single Responsibility Principle (SRP), a class must belong to only one task.
O: The open/closed principle (S.R.P.), a class should be extensible but not change the class itself.
L: Liskov's substitution principle, each subclass or derived class must be substitutable at the level of their base or parent class.
I: The principle of interface segregation, a client must never be forced to install an interface it does not use and clients must not be forced to depend on methods they do not use.
D: The principle of dependency inversion, Entities should depend on abstractions, not implementations. A high level module should not depend on a low level module. 

3)	KISS stands for "keep it simple, stupid". 
It advocates simplicity in design and that unnecessary complexity should be avoided wherever possible. 
Don't apply it too naively because trying simple means to solve something complex can be counterproductive! 

the boy scout rule! 
applicable in real life as well as in programming: "Always leave a place in a better state than you found it". 
This serves to avoid code degradation over time.

Clean architecture provides a cost-effective methodology that facilitates the development of quality code that will work better, 
is easier to modify and has fewer dependencies.
The code on the internal layers can have no knowledge of the functions on the external layers. 
Variables, functions and classes (all entities) that exist in the external layers cannot be mentioned in the more internal layers. 
It is recommended that data formats also remain separate between layers.

a code is clean when it can be read, modified, improved and understood by someone who did not code it. 

4)	If I was really looking to produce a usable application I would make a graphical interface in XAML because we did a bit of that 2 years ago. 
We could then integrate a search system by city and not by coordinates because nobody knows the coordinates of a city by head.....
What would also be more relevant would be to have a weather forecast for the next day for example.
Why not a search by continent! For example, we enter the word Europe and the software takes us to all the European capitals with their weather. 

On the longer term we could store the data with their dates and then make averages over several years and predict approximately the weather for the following years. 