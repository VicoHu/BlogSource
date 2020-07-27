import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";

// 引入ElementUI组件依赖
import ElementUI from 'element-ui';
// 引入ElementUI的样式库
import 'element-ui/lib/theme-chalk/index.css';

// 安装ElementUI插件到Vue全局
Vue.use(ElementUI);

Vue.config.productionTip = false;

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount("#app");
