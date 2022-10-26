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

The obfuscated code generates the folling exception:
```
Unhandled Exception: System.TypeLoadException: Could not load type 'TypeReferencesInNonObfuscatedAttributes.Class2' from assembly 'TypeReferencesInNonObfuscatedAttributes, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'.
   at System.Reflection.CustomAttribute._CreateCaObject(RuntimeModule pModule, IRuntimeMethodInfo pCtor, Byte** ppBlob, Byte* pEndBlob, Int32* pcNamedArgs)
   at System.Reflection.CustomAttribute.CreateCaObject(RuntimeModule module, IRuntimeMethodInfo ctor, IntPtr& blob, IntPtr blobEnd, Int32& namedArgs)
   at System.Reflection.CustomAttribute.GetCustomAttributes(RuntimeModule decoratedModule, Int32 decoratedMetadataToken, Int32 pcaCount, RuntimeType attributeFilterType, Boolean mustBeInheritable, IList derivedAttributes, Boolean isDecoratedTargetSecurityTransparent)
   at System.Reflection.CustomAttribute.GetCustomAttributes(RuntimeMethodInfo method, RuntimeType caType, Boolean inherit)
   at System.Reflection.RuntimeMethodInfo.GetCustomAttributes(Boolean inherit)
   at ohM=.oRM=.oxM=() in [...]\Agile.net-Bugs\TypeReferencesInNonObfuscatedAttributes\src\Program.cs:line 20
```