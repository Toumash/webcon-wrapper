SELECT
    wf.WF_Name,
    c.[WFCON_ID]
      , c.[WFCON_FDEFID]
      , c.[WFCON_DEFID]
      , c.[WFCON_FieldTypeID]
      , c.[WFCON_IsArchival]
      , c.[WFCON_IsTechnical]
      , c.[WFCON_ChoiceFieldType]
      , c.[WFCON_Prompt]
      , c.WFCON_IsDeleted
      , d.Name
      , d.ObjectName
      , d.EnglishName
FROM [BPS_Content].[dbo].[WFConfigurations] c
    INNER JOIN
    (SELECT
        [TypeID]
      , [Name]
      , [ObjectName]
      , [Description]
      , [EnglishName]
    FROM [BPS_Content].[dbo].[DicFieldDetailTypes])
d
    ON d.TypeID = c.WFCON_FieldTypeID
    LEFT JOIN
    (SELECT
        -- [WF_ID],
        [WF_WFDEFID],
        [WF_Name]
    FROM [BPS_Content].[dbo].[WorkFlows])
wf
    ON wf.WF_WFDEFID = c.WFCON_DEFID
where  c.WFCON_IsDeleted = 0
order by WF_Name