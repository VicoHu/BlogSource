<template>
  <div class="LoginContainer">
    <span>班级管理系统</span>
    <div class="LoginCard">
      <el-card shadow="always" body-style="padding:35px 40px;padding-bottom:20px;height:245px;width:320px;">
        <h2>登录</h2>
        <el-form :model="formData" label-width="60px" style="margin-top:40px;">
          <el-form-item label="用户名">
            <el-input type="text" v-model="formData.name"></el-input>
          </el-form-item>
          <el-form-item label="密码">
            <el-input type="text" v-model="formData.password"></el-input>
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
      formData: {
        name: "",
        password: "",
      },
    };
  },
  methods: {
    login() {
      // alert("TODO");
      this.login_loading = true;
    },
  },
};
</script>

<style lang="scss" scoped>
.LoginContainer {
  height: 100vh;
  width: 100vw;
  background-image: linear-gradient(-2deg,#ffffff 45%, #409EFF 45.1%);
  span{
    display: block;
    padding-top: 50px;
    font-weight: 900;
    color: white;
    font-size:35px;
  }
  .LoginCard {
    position: fixed;
    top: 32vh;
    right:25vh;
  }
}
</style>
