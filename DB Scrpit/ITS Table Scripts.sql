USE [ITS]
GO

/****** Object:  Table [dbo].[org_assigntest]    Script Date: 10/2/2023 2:48:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[org_assigntest](
	[sno] [int] IDENTITY(1,1) NOT NULL,
	[org_name] [nvarchar](max) NULL,
	[user_type] [nvarchar](200) NULL,
	[student_id] [nvarchar](200) NULL,
	[subjectname] [nvarchar](200) NULL,
	[set_id] [nvarchar](200) NULL,
	[starttime] [datetime] NULL,
	[endtime] [datetime] NULL,
	[duration] [int] NULL,
	[status] [nvarchar](100) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[org_batchname]    Script Date: 10/2/2023 2:48:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[org_batchname](
	[sno] [int] IDENTITY(1,1) NOT NULL,
	[org_name] [nvarchar](200) NOT NULL,
	[user_type] [nvarchar](100) NULL,
	[batch_name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_org_batchname] PRIMARY KEY CLUSTERED 
(
	[org_name] ASC,
	[batch_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[org_branchname]    Script Date: 10/2/2023 2:48:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[org_branchname](
	[sno] [int] IDENTITY(1,1) NOT NULL,
	[org_name] [nvarchar](200) NOT NULL,
	[user_type] [nvarchar](200) NULL,
	[course_name] [nvarchar](80) NOT NULL,
	[branch_name] [nvarchar](80) NOT NULL,
	[batch_name] [nvarchar](80) NOT NULL,
 CONSTRAINT [PK_org_branchname] PRIMARY KEY CLUSTERED 
(
	[org_name] ASC,
	[course_name] ASC,
	[branch_name] ASC,
	[batch_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[org_college_student]    Script Date: 10/2/2023 2:48:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[org_college_student](
	[sno] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[org_name] [nvarchar](max) NOT NULL,
	[user_type] [nvarchar](200) NOT NULL,
	[aadhaar] [nvarchar](100) NULL,
	[collegeName] [nvarchar](200) NULL,
	[collegeCode] [nvarchar](50) NULL,
	[rollNo] [nvarchar](50) NULL,
	[name] [nvarchar](150) NULL,
	[faName] [nvarchar](150) NULL,
	[course] [nvarchar](80) NULL,
	[branch] [nvarchar](10) NULL,
	[year] [nvarchar](10) NULL,
	[sem] [nvarchar](10) NULL,
	[emailID] [nvarchar](150) NULL,
	[contactNo] [nvarchar](80) NULL,
	[otherContactNo] [nvarchar](80) NULL,
UNIQUE NONCLUSTERED 
(
	[aadhaar] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[org_coursename]    Script Date: 10/2/2023 2:48:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[org_coursename](
	[sno] [int] IDENTITY(1,1) NOT NULL,
	[org_name] [nvarchar](200) NOT NULL,
	[user_type] [nvarchar](200) NULL,
	[course_name] [nvarchar](100) NOT NULL,
	[batch_name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_org_coursename] PRIMARY KEY CLUSTERED 
(
	[org_name] ASC,
	[course_name] ASC,
	[batch_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[org_exam_name]    Script Date: 10/2/2023 2:48:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[org_exam_name](
	[sno] [int] IDENTITY(1,1) NOT NULL,
	[org_name] [nvarchar](200) NOT NULL,
	[user_type] [nvarchar](200) NOT NULL,
	[exam_name] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_org_exam_name] PRIMARY KEY CLUSTERED 
(
	[org_name] ASC,
	[exam_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[org_exam_schedule]    Script Date: 10/2/2023 2:48:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[org_exam_schedule](
	[sno] [int] IDENTITY(1,1) NOT NULL,
	[course_name] [nvarchar](300) NULL,
	[branch_name] [nvarchar](300) NULL,
	[yearsem] [int] NULL,
	[subject_name] [nvarchar](300) NULL,
	[set_id] [nvarchar](max) NULL,
	[status] [nvarchar](200) NULL,
	[starttime] [datetime] NULL,
	[endtime] [datetime] NULL,
	[info] [nvarchar](max) NULL,
	[exam_name] [nvarchar](200) NULL,
	[org_name] [nvarchar](250) NULL,
	[batch_name] [nvarchar](100) NULL,
	[resdisp] [nvarchar](100) NULL,
	[anskey] [nvarchar](100) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[org_exam_set_info]    Script Date: 10/2/2023 2:48:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[org_exam_set_info](
	[sno] [int] IDENTITY(1,1) NOT NULL,
	[org_name] [nvarchar](250) NOT NULL,
	[user_type] [nvarchar](200) NOT NULL,
	[set_id] [nvarchar](50) NOT NULL,
	[exam_cat] [nvarchar](50) NOT NULL,
	[total_marks] [float] NOT NULL,
	[total_minut] [int] NOT NULL,
	[correct_marks] [float] NOT NULL,
	[wrong_marks] [float] NOT NULL,
	[exam_name] [nvarchar](max) NOT NULL,
	[subject] [nvarchar](max) NOT NULL,
	[topic] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_org_exam_set_info] PRIMARY KEY CLUSTERED 
(
	[org_name] ASC,
	[set_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[org_mstLogin]    Script Date: 10/2/2023 2:48:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[org_mstLogin](
	[SNo] [int] IDENTITY(1,1) NOT NULL,
	[uid] [nvarchar](100) NOT NULL,
	[pwd] [nvarchar](50) NULL,
	[org_name] [nvarchar](max) NULL,
	[userType] [nvarchar](100) NULL,
	[status] [nvarchar](50) NULL,
	[cp_status] [nvarchar](50) NULL,
	[loggedIn] [datetime] NULL,
	[loggedOut] [datetime] NULL,
	[loginStatus] [varchar](50) NULL,
	[mask] [nvarchar](100) NULL,
	[quesidstart] [int] NULL,
	[validfrom] [datetime] NULL,
	[validtill] [datetime] NULL,
 CONSTRAINT [PK_org_mstLogin] PRIMARY KEY CLUSTERED 
(
	[uid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[org_question_bank]    Script Date: 10/2/2023 2:48:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[org_question_bank](
	[sno] [int] IDENTITY(1,1) NOT NULL,
	[q_id] [int] NOT NULL,
	[user_type] [nvarchar](max) NOT NULL,
	[org_name] [nvarchar](250) NOT NULL,
	[exame_name] [nvarchar](max) NOT NULL,
	[subject] [nvarchar](max) NOT NULL,
	[topic] [nvarchar](max) NOT NULL,
	[question_level] [nvarchar](max) NOT NULL,
	[question] [ntext] NULL,
	[question_image] [image] NULL,
	[option_a] [ntext] NULL,
	[option_b] [ntext] NULL,
	[option_c] [ntext] NULL,
	[option_d] [ntext] NULL,
	[correct_option] [nvarchar](50) NOT NULL,
	[description] [ntext] NULL,
	[option_a_image] [image] NULL,
	[option_b_image] [image] NULL,
	[option_c_image] [image] NULL,
	[option_d_image] [image] NULL,
	[desc_image] [image] NULL,
	[lang] [nvarchar](50) NULL,
	[ques_type] [nvarchar](50) NULL,
	[input_hint] [nvarchar](500) NULL,
 CONSTRAINT [PK_org_question_bank] PRIMARY KEY CLUSTERED 
(
	[q_id] ASC,
	[org_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[org_question_paper]    Script Date: 10/2/2023 2:48:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[org_question_paper](
	[sno] [int] IDENTITY(1,1) NOT NULL,
	[user_type] [nvarchar](max) NOT NULL,
	[org_name] [nvarchar](200) NOT NULL,
	[set_id] [nvarchar](200) NOT NULL,
	[exam_cat] [nvarchar](50) NOT NULL,
	[q_no] [int] NOT NULL,
	[q_id] [int] NOT NULL,
	[exam_name] [nvarchar](max) NOT NULL,
	[subject] [nvarchar](max) NOT NULL,
	[topic] [nvarchar](max) NOT NULL,
	[question] [ntext] NULL,
	[question_image] [image] NULL,
	[option_a] [ntext] NULL,
	[option_b] [ntext] NULL,
	[option_c] [ntext] NULL,
	[option_d] [ntext] NULL,
	[correct_option] [nvarchar](50) NOT NULL,
	[description] [ntext] NULL,
	[correct_marks] [float] NOT NULL,
	[wrong_marks] [float] NOT NULL,
	[option_a_image] [image] NULL,
	[option_b_image] [image] NULL,
	[option_c_image] [image] NULL,
	[option_d_image] [image] NULL,
	[desc_image] [image] NULL,
	[lang] [nvarchar](50) NULL,
	[ques_type] [nvarchar](50) NULL,
	[input_hint] [nvarchar](500) NULL,
 CONSTRAINT [PK_org_question_paper] PRIMARY KEY CLUSTERED 
(
	[org_name] ASC,
	[set_id] ASC,
	[q_no] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[org_student_exam]    Script Date: 10/2/2023 2:48:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[org_student_exam](
	[srno] [int] IDENTITY(1,1) NOT NULL,
	[org_name] [nvarchar](max) NOT NULL,
	[user_type] [nvarchar](200) NULL,
	[student_id] [nvarchar](max) NULL,
	[set_id] [nvarchar](50) NULL,
	[attemp_no] [int] NULL,
	[q_id] [int] NULL,
	[q_no] [int] NULL,
	[answer] [nvarchar](50) NULL,
	[correct_option] [nvarchar](50) NULL,
	[correct_marks] [float] NULL,
	[wrong_marks] [float] NULL,
	[sno] [int] NULL,
	[start_time] [datetime] NULL,
	[submit_time] [datetime] NULL,
	[total_time_take] [int] NULL,
	[ques_mark] [nvarchar](50) NULL,
	[time_taken] [int] NULL,
	[subj] [nvarchar](100) NULL,
	[exam] [nvarchar](100) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[org_student_exam_temp]    Script Date: 10/2/2023 2:48:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[org_student_exam_temp](
	[srno] [int] IDENTITY(1,1) NOT NULL,
	[org_name] [nvarchar](max) NOT NULL,
	[user_type] [nvarchar](200) NULL,
	[student_id] [nvarchar](max) NULL,
	[set_id] [nvarchar](50) NULL,
	[attemp_no] [int] NULL,
	[q_id] [int] NULL,
	[q_no] [int] NULL,
	[answer] [nvarchar](50) NULL,
	[correct_option] [nvarchar](50) NULL,
	[correct_marks] [float] NULL,
	[wrong_marks] [float] NULL,
	[sno] [int] NULL,
	[start_time] [datetime] NULL,
	[submit_time] [datetime] NULL,
	[total_time_take] [int] NULL,
	[ques_mark] [nvarchar](50) NULL,
	[time_taken] [int] NULL,
	[subj] [nvarchar](100) NULL,
	[exam] [nvarchar](100) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[org_student_info]    Script Date: 10/2/2023 2:48:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[org_student_info](
	[sno] [int] IDENTITY(1,1) NOT NULL,
	[org_name] [nvarchar](300) NOT NULL,
	[user_type] [nvarchar](200) NULL,
	[st_rollno] [nvarchar](100) NOT NULL,
	[st_course] [nvarchar](100) NULL,
	[st_branch] [nvarchar](100) NULL,
	[st_yearsem] [int] NULL,
	[st_name] [nvarchar](500) NULL,
	[st_email] [nvarchar](200) NULL,
	[st_phone] [nvarchar](200) NULL,
	[st_status] [nvarchar](200) NULL,
	[st_batch] [nvarchar](80) NULL,
 CONSTRAINT [PK_org_student_info] PRIMARY KEY CLUSTERED 
(
	[org_name] ASC,
	[st_rollno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[org_student_result]    Script Date: 10/2/2023 2:48:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[org_student_result](
	[sno] [int] IDENTITY(1,1) NOT NULL,
	[org_name] [nvarchar](max) NOT NULL,
	[user_type] [nvarchar](200) NULL,
	[student_id] [nvarchar](max) NULL,
	[set_id] [nvarchar](50) NULL,
	[attempt_no] [int] NULL,
	[total_marks] [float] NULL,
	[obtain_marks] [float] NULL,
	[date] [datetime] NULL,
	[remaning_min] [int] NULL,
	[correct_answer] [int] NULL,
	[wrong_answer] [int] NULL,
	[un_answer] [int] NULL,
	[examstatus] [nvarchar](50) NULL,
	[submitexam_time] [datetime] NULL,
	[course] [nvarchar](200) NULL,
	[branch] [nvarchar](200) NULL,
	[yearsem] [int] NULL,
	[examname] [nvarchar](500) NULL,
	[subjectname] [nvarchar](500) NULL,
	[atendance] [nvarchar](200) NULL,
	[studentstatus] [nvarchar](200) NULL,
	[linkopentime] [datetime] NULL,
	[linkclosetime] [datetime] NULL,
	[resultdisplay] [nvarchar](50) NULL,
	[batch_name] [nvarchar](100) NULL,
	[answerkey] [nvarchar](50) NULL,
	[opencount] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[org_subject_name]    Script Date: 10/2/2023 2:48:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[org_subject_name](
	[sno] [int] IDENTITY(1,1) NOT NULL,
	[org_name] [nvarchar](250) NOT NULL,
	[user_type] [nvarchar](200) NOT NULL,
	[subject_name] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_org_subject_name] PRIMARY KEY CLUSTERED 
(
	[org_name] ASC,
	[subject_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[org_test_examname]    Script Date: 10/2/2023 2:48:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[org_test_examname](
	[sno] [int] IDENTITY(1,1) NOT NULL,
	[org_name] [nvarchar](250) NULL,
	[course_name] [nvarchar](200) NULL,
	[branch_name] [nvarchar](200) NULL,
	[yearsem] [int] NULL,
	[exam_name] [nvarchar](250) NULL,
	[batch_name] [nvarchar](100) NULL
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[org_test_subject_name]    Script Date: 10/2/2023 2:48:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[org_test_subject_name](
	[sno] [int] IDENTITY(1,1) NOT NULL,
	[course_name] [nvarchar](150) NOT NULL,
	[branch_name] [nvarchar](150) NOT NULL,
	[yearsem] [int] NOT NULL,
	[exam_name] [nvarchar](200) NOT NULL,
	[subject_name] [nvarchar](150) NOT NULL,
	[org_name] [nvarchar](200) NOT NULL,
	[batch_name] [nvarchar](80) NOT NULL
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[org_test_subject_setid]    Script Date: 10/2/2023 2:48:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[org_test_subject_setid](
	[sno] [int] IDENTITY(1,1) NOT NULL,
	[course_name] [nvarchar](200) NULL,
	[branch_name] [nvarchar](200) NULL,
	[yearsem] [int] NULL,
	[exam_name] [nvarchar](200) NULL,
	[subject_name] [nvarchar](200) NULL,
	[set_id] [nvarchar](200) NULL,
	[org_name] [nvarchar](200) NULL,
	[batch_name] [nvarchar](100) NULL
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[org_topic_name]    Script Date: 10/2/2023 2:48:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[org_topic_name](
	[sno] [int] IDENTITY(1,1) NOT NULL,
	[org_name] [nvarchar](200) NOT NULL,
	[user_type] [nvarchar](200) NOT NULL,
	[subject_name] [nvarchar](100) NOT NULL,
	[topic_name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_org_topic_name] PRIMARY KEY CLUSTERED 
(
	[org_name] ASC,
	[subject_name] ASC,
	[topic_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[org_yearsem]    Script Date: 10/2/2023 2:48:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[org_yearsem](
	[sno] [int] IDENTITY(1,1) NOT NULL,
	[org_name] [nvarchar](200) NOT NULL,
	[user_type] [nvarchar](200) NULL,
	[course_name] [nvarchar](80) NOT NULL,
	[branch_name] [nvarchar](70) NOT NULL,
	[yearsem] [int] NOT NULL,
	[batch_name] [nvarchar](80) NOT NULL,
 CONSTRAINT [PK_org_yearsem] PRIMARY KEY CLUSTERED 
(
	[org_name] ASC,
	[course_name] ASC,
	[branch_name] ASC,
	[yearsem] ASC,
	[batch_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


