# Type references in non obfuscated attributes

Types that gets obfuscated and are used in attributes are not always changed in the attributes.

For this check the original decompilation:  
![](docs/Original.png)

And the obfuscated one:  
![](docs/Obfuscated.png)

And here is Class2 obfuscated (it's an empty class):  
![](docs/Obfuscated_Class2.png)

As you can see "Class2" was obfuscated, but the references in the attributes were not always changed.  
If you check the original code/obfuscation, you will notice, that the references in the second and third attribute was not changed.