# wlan10

wlan10 is a Wi-Fi network manager for Windows. It allows users to set the preferred connection order of Wi-Fi networks, so that your computer will always connect to the Wi-Fi you prefer when multiple networks are available.

This functionality was available in older versions of Windows, but was removed in Windows 10. wlan10 exists to fill this gap, without the need for users to hack around with the command-line `netsh` commands.

## Requirements

* Windows 10 or 8.1
* .NET 4 or newer
* A PC with Wi-Fi support

## Usage

1. Download wlan10 from [releases](https://github.com/afit/wlan10/releases) and run it.
2. wlan10 will show a list of networks that your computer is configured to automatically connect to.

    wlan10 can't add Wi-Fi networks to your list: you should add new networks by connecting to them through Windows as usual.

3. Drag and drop networks to change the preferred connection order to your liking, and click `Save` to store this new order.

    Windows will now prefer the networks which you put on top, selecting the highest positioned available network.
    
    Setting autoconnect and autoswitching doesn't require saving.  

wlan10 is only required for configuring preferred network connect order: it does not need to remain running in the background, and can even be deleted after use.

> **Note:** What is autoswitching?
>
> The `autoSwitch` (`WLANProfile`) element determines the roaming behavior of an auto-connected network when a more preferred network is in range. This element is optional.
>
> If `autoSwitch` is `true` and `connectionMode` is set to `auto`, a connection to a more preferred network must be attempted whenever a more preferred network comes into range. A more preferred network is one that is ordered higher in the list of preferred wireless networks. This connection attempt occurs when connected to another network.
>
> An `autoSwitch` value set to `true` results in a higher frequency of periodic scanning for new networks. This may result in increased radio frequency pollution from these periodic scans and increased power consumption used by the wireless network adapter.

## Support

Create a [GitHub issue](https://github.com/Bertware/wlan10/issues) if you have suggestions or problems.

## Credits & licensing

[Bertware](http://www.bertware.net) created wlan10 and ran it up until version 1.1.2.

This project is subject to the Mozilla Public License Version 2.0. A copy of the license is included in this repository.

### Libraries used in this project
#### GongSolutions.WPF.DragDrop

The [`GongSolutions.WPF.DragDrop`](https://github.com/punker76/gong-wpf-dragdrop) library is used as an NuGet package in wlan10. `GongSolutions.WPF.DragDrop` code is public under the BSD 3-Clause License.

    Copyright © 2015, Jan Karger (Steven Kirk). All rights reserved.

    Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:

    Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.

    Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation  and/or other materials provided with the distribution.

    Neither the name of gong-wpf-dragdrop nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.

    THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
