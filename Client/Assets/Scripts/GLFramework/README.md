# GLFramework

GLFramework 是一个架构代码框架，分为可重用代码和特定代码两大部分。

## 目录结构

```plaintext
.
├── GLFramework
│   ├── ReusableCode
│   │   ├── Architecture
│   │   │   ├── Command
│   │   │   ├── Event
│   │   │   ├── IOC
│   │   │   ├── Rules
│   │   │   └── Singleton
│   │   ├── Layers
│   │   │   ├── Controller
│   │   │   ├── Model
│   │   │   ├── System
│   │   │   └── Utility
│   ├── SpecificCode
│   │   ├── PresentationLayerCode
│   │   ├── UnderLyingCode
│   │   │   ├── Architecture
│   │   │   ├── Model
│   │   │   └── Utility
└── GLFramework.meta
目录详情
ReusableCode (可重用代码)
Architecture (架构)
Command: 实现命令模式的相关代码
Event: 事件处理相关代码
IOC: 依赖注入容器相关代码
Rules: 业务规则相关代码
Singleton: 单例模式相关代码
Layers (层)
Controller: 控制层代码
Model: 数据模型代码
System: 系统级别的代码
Utility: 工具类代码
SpecificCode (特定代码)
PresentationLayerCode (展示层代码)
展示层相关的代码
UnderLyingCode (底层代码)
Architecture: 底层架构相关代码
Model: 底层数据模型代码
Utility: 底层工具类代码
使用说明
根据项目需要，可以在 ReusableCode 中编写通用的代码，并在 SpecificCode 中编写特定的代码，保证代码的复用性和可维护性。


