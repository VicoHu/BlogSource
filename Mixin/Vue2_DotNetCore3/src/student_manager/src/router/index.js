import Vue from "vue";
import VueRouter from "vue-router";
import StudentHome from "../views/StudentHome.vue";
import AdminHome from "../views/AdminHome.vue";
import TeacherHome from "../views/TeacherHome.vue";
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
    path: "/TeacherHome",
    name: "TeacherHome",
    component: TeacherHome,
    children: [
      {
        path: "NormalTest",
        name: "NormalTest",
        // 懒加载
        component: () => import("@/views/teacher/NormalTest.vue")
      },
      {
        path: "StageTest",
        name: "StageTest",
        component: () => import("@/views/teacher/StageTest.vue")
      },
      {
        path: "MyStudent",
        name: "MyStudent",
        component: () => import("@/views/teacher/MyStudent.vue")
      }
    ],
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
