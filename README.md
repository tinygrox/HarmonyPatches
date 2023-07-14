# KSP Harmony 汉化补丁合集
此项目主要用来存放本人制作的一系列关于坎巴拉太空计划 Mod 的汉化补丁。

本汉化补丁专门用于存放针对那些文本采用硬编码形式存储的、未内置本地化接口的 Mod。

汉化原理：使用 C# Harmony2 库的功能，对 Mod 的类方法进行修改，从而达到汉化目的，所以这是一个补丁，需要安装原 Mod。

好处：这样就能像 RimWorld 的汉化包那样，汉化工作就被拆分成一个个单独的 Mod，无需改动原 Mod 的代码即可实现汉化。

## 安装 & 使用

- 首先去 CKAN 下载安装 **HarmonyKSP**（搜 **Harmony** 就能直接出来），如已安装则跳过，CKAN 显示的名字是**Harmony 2**，GitHub 传送门：https://github.com/KSPModdingLibs/HarmonyKSP，坎巴拉怎么安装 Mod 应该不用教吧？主要检查 **GameData** 目录下是否存在 **000_Harmony** 文件夹，且里面是不是有 2 个 dll 文件。

- 去[这里](https://github.com/tinygrox/KSPHarmonyPatches/releases)下载：然后将下载的压缩文件解压后放入游戏的 **GameData** 目录下，完整路径应为：`GameData\TinygroxHarmonyPatches\`

然后进入游戏即可。

## 目前支持 Mod

- **Advanced Fly-By-Wire (Windows)** - [GitHub链接](https://github.com/linuxgurugamer/ksp-advanced-flybywire)

- **[x] Science! Continued** - [GitHub链接](https://github.com/linuxgurugamer/KSP-X-Science)

## 更新日志

23/07/15新增对 **[x] Science! Continued** 支持
