# UITransitions Unity3D
Extremely easy to use UI Transitions which make your code more readable and neater.

<B>What's the point of it?</b>
Managing your UI menus can get pretty complicated and messy, whenever you want to enable/disable a menu you need to have a reference to it, you can get reference by assigning each menu manually to a specific var, but soon you create too many vars to keep track of them. You can use gameObject.Find... but that is often slow to use if you have a lot of menus to manage (also code get's long pretty soon since you have to create reference to each menu). So this was annoying me and I decided to write a system that you can use to easily manipulate a lot of menus and have good control over transitions.


<b>How to use it:</b>

1. Add UITransitions script to MainCamera (or any other GO that is always enabled)
2. Create UI canvas
3. Set reference to that UI Canvas in variable called in variable UIParent in UITransitions script you just added
4. Create empty GOs depending on how many UI element groups you want (we are going to call these objects as GroupParent)
5. Put those empty GOs as child objects in UI canvas (watch out for their local position, you should put them all to zeros)
6. Name them so you can identify different UI groups
7. Attach one of the T_xxx scripts to each GroupParent (it's gonna add RectTransform automatically)
7. Add UI elements by wish as children of some GroupParent

Now you can enable/disable specific groups of UI elements by just writing this line of code anywhere insede the project:

```C#
SetActive("MainMenu", false);
```

This line will pass "false" value to T_xxx which is attached to GroupParent with name "MainMenu". If you misspell the name
it's gonna throw you a error and it will write both your misspelled name and the name that has the most similiar spelling 
as the one you entered (by using Levenshtein Distance (this script is not written by me)).

How to write custom transitions (please add them to this repo):

```C#
using UnityEngine;
using System.Collections;

public class T_Instant : MonoBehaviour {
    void SetActive(bool active){
        gameObject.SetActive(active);
    }
}
```

Here is example of the most simple transitions which instantly snaps value to either disabled or enabled. Try building on that.

<b>TO-DO List:</b>

1. Improve example scene.
2. Different transitions on "rollout" and "rollin".
3. Simplified dynamic adding of transitions
4. Marking transitions as one time use
5. Add comments, explanations and documentation.

<b>How to use it:</b>
Copy the whole folder somwehere inside your assets folder in the project you want to use it in.


