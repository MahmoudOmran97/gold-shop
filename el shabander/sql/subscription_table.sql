-- هذا الجدول يتم إنشاؤه تلقائيًا بواسطة البرنامج عند أول تشغيل (SubscriptionManager.EnsureTable)
-- هذا السكريبت هنا فقط للتوثيق أو لإنشائه يدويًا لو احتجت ذلك.

IF OBJECT_ID('dbo.tb_subscription', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.tb_subscription
    (
        id                     INT           NOT NULL PRIMARY KEY,  -- دائمًا = 1 (سجل واحد لكل جهاز/قاعدة بيانات)
        machine_serial         NVARCHAR(200) NULL,                  -- الرقم التسلسلي لجهاز العميل (من Win32_BIOS)
        start_date             DATETIME      NOT NULL,              -- تاريخ أول تفعيل
        end_date               DATETIME      NOT NULL,              -- تاريخ انتهاء الاشتراك الحالي
        last_checked           DATETIME      NOT NULL,              -- آخر وقت تم فيه فحص الاشتراك (لمنع تلاعب الساعة)
        last_activation_code   NVARCHAR(400) NULL                   -- آخر كود تفعيل تم استخدامه (لمنع إعادة استخدامه)
    )
END
