<template>
  <div class="LoginContainer">
    <span>班级管理系统</span>
    <div class="LoginCard">
      <el-card
        shadow="always"
        body-style="padding:35px 40px;padding-bottom:20px;height:325px;width:380px;"
      >
        <h2>登录</h2>
        <el-form :model="formData" label-width="60px" style="margin-top:40px;">
          <el-form-item label="用户名">
            <el-input type="text" v-model="formData.name"></el-input>
          </el-form-item>
          <el-form-item label="密码">
            <el-input type="text" v-model="formData.password"></el-input>
          </el-form-item>
          <el-form-item label="身份" style="text-align:left;">
            <el-select v-model="formData.permissionCode" placeholder="请选择">
              <el-option
                v-for="item in permissionList"
                :key="item.code"
                :label="item.name"
                :value="item.code"
              >
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label-width="0px">
            <el-button type="primary" @click="login" :loading="login_loading"
              >登录</el-button
            >
          </el-form-item>
        </el-form>
      </el-card>
    </div>
  </div>
</template>

<script>
export default {
  name: "login",
  data() {
    return {
      login_loading: false,
      // 登录加载状态
      // 身份列表
      permissionList: [],
      formData: {
        name: "",
        password: "",
        permissionCode: null,
      },
    };
  },
  created() {
    // 获取权限列表
    this.axios
      .get("api/Permissions/GetPermission")
      .then((res) => {
        this.permissionList = res.data;
        console.log(this.permissionList);
      })
      .catch((err) => {
        console.error(err);
      });
  },
  methods: {
    login() {
      // alert("TODO");
      this.login_loading = true;
      let url = "";
      let routerList = [];
      switch (this.formData.permissionCode) {
        case 1:
          url = `api/admin/PostLogin?UserName=${this.formData.name}&Password=${this.formData.password}`;
          break;
        case 2:
          url = `api/teacher/PostLogin?UserName=${this.formData.name}&Password=${this.formData.password}`;
          routerList = [{
            path: "/TeacherHome",
            name: "TeacherHome",
            component: () => import("@/views/TeacherHome.vue"),
            children: [
              {
                path: "NormalTest",
                name: "NormalTest",
                // 懒加载
                component: () => import("@/views/teacher/NormalTest.vue"),
              },
              {
                path: "StageTest",
                name: "StageTest",
                component: () => import("@/views/teacher/StageTest.vue"),
              },
              {
                path: "MyStudent",
                name: "MyStudent",
                component: () => import("@/views/teacher/MyStudent.vue"),
              },
            ],
          }];
          break;
        case 3:
          url = `api/student/PostLogin?UserName=${this.formData.name}&Password=${this.formData.password}`;
          break;
      }
      this.axios
        .post(url)
        .then((res) => {
          if (res.data.state == true) {
            this.$store.commit("Set_UserInfo",res.data.info[0]);
            this.$router.addRoutes(routerList);
            this.$router.push(routerList[0].path);
          }
        })
        .catch((err) => {
          console.error(err);
        });
    },
  },
};
</script>

<style lang="scss" scoped>
.LoginContainer {
  height: 100vh;
  width: 100vw;
  background-image: linear-gradient(-2deg, #ffffff 45%, #409eff 45.1%);
  span {
    display: block;
    padding-top: 50px;
    font-weight: 900;
    color: white;
    font-size: 35px;
  }
  .LoginCard {
    position: fixed;
    top: 32vh;
    right: 25vh;
  }
}
</style>
