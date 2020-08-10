import os
import re
import requests as rq
from bs4 import BeautifulSoup
import xlwt
import time

# 运行需要运行以下命令，以安装依赖
"""
pip install requests
pip install BeautifulSoup4
pip install html5lib
pip install xlwt
"""


class DouBanMovieSpider:
    def __init__(self, url, num):
        """
        豆瓣音乐排行榜爬虫
        :param url:网址
        :param num:要爬取的数量
        :param headers:请求头
        """
        self.url = url
        # 要爬取的域名
        self.num = num
        # 要爬取的数量，不满25的倍数舍弃余数个数，最大250
        self.data = []

    def MatchHtml(self, HtmlContent):
        """
        排行榜网页解析，并提取相关信息
        :param HtmlContent:网页内容
        """
        # 使用Beautifulsoap库，并利用html5lib解析库对网页进行解析
        soup = BeautifulSoup(HtmlContent, "html5lib")
        # 找到一页网页中，所有单个电影的div的集合
        for item in soup.select("div.item"):
            try:
                # 获得电影名
                title = item.select("span.title")[0].string
                # 获得排名
                index = item.select("em")[0].string
                # 获得电影别名
                foreignTitle = item.select("span.title")[
                    1].string.replace("\xa0/\xa0", "")
                # 获得电影简介
                introduce = item.select("span.inq")[0].string
                # 获得电影基础信息，并进行信息格式预处理
                info = item.select("div.bd p")[0].string.replace(
                    "\n", "").replace(" ", "").replace("\xa0", " ")
                # 获得其他信息
                other = info.split("...")[1].strip()
                # 获得电影的评分信息
                star = item.select("div.star span")[1].string
                # 获得该电影的详细页面
                detailUrl = item.select("div.pic a")[0].attrs["href"]
            except IndexError as e:
                # 出现异常不做处理
                pass
            self.data.append({
                "index": index,
                "title": title,
                "foreignTitle": foreignTitle,
                "introduce":  introduce,
                "star": star,
                "time": other.split("/")[0].strip(),
                "contry": other.split("/")[1].strip(),
                "type": other.split("/")[2].strip(),
                "detailUrl": detailUrl
            })

    def run(self):
        """
        运行爬虫
        """
        print("开始启动爬虫...")
        for i in range(int(self.num / 25)):
            url = self.url + "?start=" + str(i * 25)
            print("正在爬取第 " + str(i + 1) + " 页:" + url)
            RqObj = rq.get(url, headers={
                'User-Agent': 'Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/79.0.3945.88 Safari/537.36'})
            # Requests实例对象
            HtmlContent = RqObj.content.decode(
                "utf-8").replace('<br>', '').replace('<br/>', '')
            print("正在解析第 " + str(i + 1) + " 页...")
            self.MatchHtml(HtmlContent)
            print("第 " + str(i + 1) + " 页解析完成...")
        return self.data

    def SaveToExcel(self, excelName="MovieInfo_" + time.strftime("%Y_%m_%d_%H_%M_%S", time.localtime()) + ".xls"):
        """
        保存数据到excel表格
        :param excelName: 保存的excel的名字，不填则默认以 MovieInfo_(当前时间).xls
        """
        # 创建一个workbook 设置编码
        workBook = xlwt.Workbook(encoding='utf-8')
        # 创建一个worksheet
        workSheet = workBook.add_sheet('My Worksheet')
        # 写入表格页头 参数为（行，列，值）
        workSheet.write(1, 0, "排名")
        workSheet.write(1, 1, "影片名")
        workSheet.write(1, 2, "别称")
        workSheet.write(1, 3, "简介")
        workSheet.write(1, 4, "上映时间")
        workSheet.write(1, 5, "国家")
        workSheet.write(1, 6, "类型")
        workSheet.write(1, 7, "评分")
        workSheet.write(1, 8, "详细")
        # 遍历我们的数据列表，获得到每一条电影信息的dict
        for item in self.data:
            # 计算出当前的行号
            line = 1 + int(item["index"])
            # 写入一行电影信息
            workSheet.write(line, 0, item["index"])
            workSheet.write(line, 1, item["title"])
            workSheet.write(line, 2, item["foreignTitle"])
            workSheet.write(line, 3, item["introduce"])
            workSheet.write(line, 4, item["time"])
            workSheet.write(line, 5, item["contry"])
            workSheet.write(line, 6, item["type"])
            workSheet.write(line, 7, item["star"])
            workSheet.write(line, 8, item["detailUrl"])
        # 判断是否存在data文件夹
        if os.path.exists("data"):
            # 存在则保存excel文件到data文件夹
            workBook.save('data\\' + excelName)
        else:
            # 反之创建data文件夹，然后保存excel文件到data文件夹
            os.makedirs("data")
            workBook.save('data\\' + excelName)
        print("电影数据已经保存到 " + os.path.dirname(os.path.realpath(__file__)
                                             ) + "\data\\" + excelName)
        print("按任意键，打开数据保存的文件夹")
        os.system("pause")
        os.system("start explorer %s" % os.path.dirname(
            os.path.realpath(__file__)) + "\data")
    
    def printAll(self):
        """
        在命令行格式化输出所有电影
        """
        for item in self.data:
            print("===========================")
            print("排名\t\t" + item["index"])
            print("影片名\t\t" + item["title"])
            print("别称\t\t" + item["foreignTitle"])
            print("简介\t\t" + item["introduce"])
            print("上映时间\t" + item["time"])
            print("国家\t\t" + item["contry"])
            print("类型\t\t" + item["type"])
            print("评分\t\t" + item["star"])
            print("详细\t\t" + item["detailUrl"])


if __name__ == "__main__":
    # 第二个参数只支持25的倍数，不满25的倍数舍弃余数个数
    # 实例化类
    spider = DouBanMovieSpider("https://movie.douban.com/top250", 250)

    # 运行爬虫实例
    spider.run()

    # 命令行格式化输出所有电影
    spider.printAll()

    # 保存数据到excel文件
    spider.SaveToExcel()
