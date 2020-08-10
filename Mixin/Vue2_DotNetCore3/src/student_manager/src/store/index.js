import Vue from "vue";
import Vuex from "vuex";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    // 登录状态
    LoginState: false,
    // 用户信息对象
    UserInfo: {},
    TeacherRouter: {},
  },
  mutations: {
    Set_UserInfo(state, obj) {
      state.UserInfo = obj;
    },
  },
  actions: {},
  modules: {},
});
