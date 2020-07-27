<template>
  <div class="TeacherHome">
    <!-- 左侧导航区域 -->
    <div class="left">
      <el-menu
        default-active="1-1"
        class="el-menu-vertical-demo"
        @select="handleNavSelect"
      >
        <el-submenu index="1">
          <template slot="title">
            <i class="el-icon-location"></i>
            <span>学生成绩管理</span>
          </template>
          <el-menu-item index="1-1">平时考试管理</el-menu-item>
          <el-menu-item index="1-2">阶段考试管理</el-menu-item>
        </el-submenu>
        <el-menu-item index="2">
          <template slot="title">
            <i class="el-icon-menu"></i>
            <span slot="title">我的学生</span>
          </template>
        </el-menu-item>
      </el-menu>
    </div>
    <!-- 右侧主页面区域 -->
    <div class="right">
      <el-tabs v-model="TabActiveName" type="card">
        <el-tab-pane :label="TabActiveTitle" name="first">
          <!-- 子路由视图渲染 -->
          <router-view></router-view>
        </el-tab-pane>
      </el-tabs>
    </div>
  </div>
</template>

<script>
// @ is an alias to /src
export default {
  name: "TeacherHome",
  data() {
    return {
      TabActiveName: "first",
      TabActiveTitle: "平时考试管理"
    }
  },
  methods:{
    /**
     * 导航点击事件
     */
    handleNavSelect(key){
      // 点击时会或得到点击项的key也就是标签中的index
      switch(key){
        case "1-1":
          this.TabActiveTitle = "平时考试管理";
          // 跳转url
          this.$router.push("/teacherhome/normaltest");
          break;
        case "1-2":
          this.TabActiveTitle = "阶段考试管理";
          // 跳转url
          this.$router.push("/teacherhome/stagetest");
          break;
        case "2":
          this.TabActiveTitle = "我的学生";
          // 跳转url
          this.$router.push("/teacherhome/mystudent");
          break;
      }
    }
  }
};
</script>

<style lang="scss" scoped>
.TeacherHome {
  display: flex;
  flex-direction: row;
  .left {
    display: flex;
    flex-direction: column;;
    width: 220px;
    height: 100vh;
    .el-menu-vertical-demo{
      height: 100%;
    }
  }
  .right {
    height: 100vh;
    width: 100%;
  }
}
</style>
