BDDD,Base Library For DDD Pattern
====
###项目说明：
该项目基于ApWorks框架开发，Apworks框架地址：[https://github.com/daxnet/Apworks](https://github.com/daxnet/Apworks)。为了学习DDD，我基本把他复制了一遍，其中做了一些小小的变动。
<br/>
框架引入了一些经典DDD中的概念：聚合根，仓储，领域模型等等，并对这些概念进行了封装。在使用该框架进行开发的时候能够更加容易的遵循DDD的一些理念，简化了一些基本的声明与操作。
框架目前包含的一些概念：
* 聚合根  
* 缓存  
* 框架配置  
* AOP拦截  
* 仓储  
* IOC  

**如何使用**  
1. 下载本项目，解压后找到根目录下的AutoBuild.bat运行（确定本机已经安装.net framework 3.5）  
2. 运行成功后会自动在根目录下生成一个bin目录，里面包含了所有BDDD的DLL，直接在项目中引用这些DLL即可。  
3. 阅读 [如何在项目中使用BDDD？](https://github.com/qianlifeng/BDDD/wiki/%E5%A6%82%E4%BD%95%E9%9B%86%E5%90%88BDDD%E5%88%B0%E9%A1%B9%E7%9B%AE%E4%B8%AD%EF%BC%9F)

**项目结构**  
1. BDDD 项目核心，定义了用于领域开发的各种概念模型。包括  
2. BDDD.Repository.NHibernate 实现了NHibernate的Repository模式。  
3. BDDD.ObjectContainers.Unity 实现了基于Unity的IOC实现，用于依赖注入  
4. BDDD.Cache.MSEnterpriseLibrary 实现了基于微软企业库的缓存管理  
