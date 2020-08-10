import Vue from "vue";
import VueRouter from "vue-router";
import StudentHome from "../views/StudentHome.vue";
import AdminHome from "../views/AdminHome.vue";
// import TeacherHome from "../views/TeacherHome.vue";
import login from "../views/login.vue";

Vue.use(VueRouter);

const routes = [
  {
    path: "/",
    name: "StudentHome",
    redirect: "/login",
    // component: StudentHome
  },
  {
    path: "/login",
    name: "login",
    component: login,
  },
  {
    path: "/StudentHome",
    name: "StudentHome",
    component: StudentHome,
  },
  
  {
    path: "/AdminHome",
    name: "AdminHome",
    component: AdminHome,
  },
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes,
});

export default router;
