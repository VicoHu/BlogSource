<template>
  <div class="MyStudedntContainer">
    <el-card>
      <h2>新增学生</h2>
      <el-form :model="formData" label-width="80px">
        <el-form-item label="学生姓名">
          <el-input
            v-model="formData.Name"
            placeholder="请输入学生姓名"
          ></el-input>
        </el-form-item>
        <el-form-item label="学号">
          <el-input
            v-model="formData.StudentId"
            placeholder="请输入学号"
          ></el-input>
        </el-form-item>
        <el-form-item label="学生性别" style="text-align:left;">
          <el-select v-model="formData.Gender" placeholder="请输入性别">
            <el-option
              :key="1"
              :label="'男'"
              :value="true"
            ></el-option>
            <el-option
              :key="2"
              :label="'女'"
              :value="false"
            ></el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="手机号">
          <el-input
            v-model="formData.Phone"
            placeholder="请输入手机号"
          ></el-input>
        </el-form-item>
        <el-form-item label="邮箱">
          <el-input
            v-model="formData.Email"
            placeholder="请输入手机号"
          ></el-input>
        </el-form-item>
        <el-form-item label-width="0px">
          <el-button type="primary" @click="NewStudent">添加</el-button>
        </el-form-item>
      </el-form>
    </el-card>
    <el-card shadow="always">
      <el-table :data="studentList">
        <el-table-column prop="name" label="姓名"></el-table-column>
        <el-table-column prop="gender" label="性别">
          <template slot-scope="scope">
            <div>
              <el-tag type="primary">
                {{ scope.row.gender ? "男" : "女" }}
              </el-tag>
            </div>
          </template>
        </el-table-column>
        <el-table-column prop="studentId" label="学号"></el-table-column>
        <el-table-column prop="phone" label="手机号"></el-table-column>
      </el-table>
    </el-card>
  </div>
</template>

<script>
export default {
  name: "MyStudednt",
  data() {
    return {
      studentList: [],
      formData: {
        UserId: 0,
        Name: null,
        Gender: null,
        Phone: "",
        Email: "",
        ImgUrl: "",
        ClassId: 4,
        TeacherUserId: this.$store.state.UserInfo.id,
        StudentId: null,
      },
    };
  },
  created() {
    this.axios
      .get(
        "api/student/GetStudentsByTeacherUserId?UserId=" +
          this.$store.state.UserInfo.id
      )
      .then((res) => {
        res.data.forEach((element) => {
          this.studentList.push(element);
        });
        console.log(res.data);
      })
      .catch((err) => {
        console.error(err);
      });
  },
  methods: {
    NewStudent() {
      this.axios
        .post(
          `api/student/PostAdd?UserId=${this.formData.UserId}&Name=${this.formData.Name}&Gender=${this.formData.Gender}&Phone=${this.formData.Phone}&Email=${this.formData.Email}&ImgUrl=${this.formData.ImgUrl}&ClassId=${this.formData.ClassId}&TeacherUserId=${this.formData.TeacherUserId}&StudentId=${this.formData.StudentId}`
        )
        .then((res) => {
          console.log(res);
          alert(res.data);
        })
        .catch((err) => {
          console.error(err);
        });
    },
  },
};
</script>

<style lang="scss" scoped>
.MyStudedntContainer {
}
</style>
