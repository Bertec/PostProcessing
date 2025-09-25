# Post-processing Stack w/ Multiview Support

This repository adds Multiview support to PostProcessing v3.4.0 on Android VR platforms.
The default PostProcessing Stack v2 from Unity works with Unity Built-in Render Pipeline. However, when Multiview is selected for rendering, left eye in the HMD is completely white. 
This makes it impossible to utilize Multiview optimization, especially with Vulkan rendering target on Android VR devices.

This is not a case for URP counterpart.

Instructions
------------

Either 
* Download the repo and put under your Packages folder of the project, such as: `<YourProject>\Packages\com.unity.postprocessing`

or 
* [Add the repo through Package Manager](https://docs.unity3d.com/Manual/upm-ui-giturl.html). 


License
-------

Unity Companion License (see [LICENSE](LICENSE.md))
Original Post Processing Stack v2 is developed by Unity.
The changes to this repo is only to add Multiview support for Vulkan rendering target on Android VR devices.
