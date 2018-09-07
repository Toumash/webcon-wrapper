SELECT TOP (1000) [PATH_ID]
      ,[PATH_STPID]
      ,[PATH_NextSTPID]
      ,[PATH_FinishOtherTaskTypeID]
      ,[PATH_IsDynamicAssign]
      ,[PATH_AssignCONFID]
      ,[PATH_IsDynamicAssignDW]
      ,[PATH_AssignDWCONFID]
      ,[PATH_SendStandardEmails]
      ,[PATH_SendStandardEmailsDW]
      ,[PATH_IsBackAction]
      ,[PATH_ControlType]
      ,[PATH_AssigType]
      ,[PATH_CausesValidation]
      ,[PATH_TSInsert]
      ,[PATH_TSUpdate]
      ,[PATH_RowVersion]
      ,[PATH_IsDeleted]
      ,[PATH_Order]
      ,[PATH_ShowConfirm]
      ,[PATH_StayInEditForm]
      ,[PATH_MarkCurrentStepAsCompleted]
      ,[PATH_CreateDWInformationTask]
      ,[PATH_DesignerData]
      ,[PATH_IsDefault]
      ,[PATH_ShowInDiagram]
      ,[PATH_IsEnableOnSmartPhone]
      ,[PATH_MinFinishedTasksModeId]
      ,[PATH_MinFinishedTasks]
      ,[PATH_MinFinishedTasksPercent]
      ,[PATH_ApprovalCommandID]
      ,[PATH_IsMailApprovalEnabled]
      ,[PATH_ControlTypeDW]
      ,[PATH_AllowCover]
      ,[PATH_CommentRequired]
      ,[PATH_PredefinedAsgnEnabled]
      ,[PATH_ConstAsgnEnabled]
      ,[PATH_PredefinedAsgnEnabledDW]
      ,[PATH_ConstAsgnEnabledDW]
      ,[PATH_PredefinedAsgnCovers]
      ,[PATH_ConstAsgnCovers]
      ,[PATH_PredefinedAsgnCoversDW]
      ,[PATH_ConstAsgnCoversDW]
      ,[PATH_AllowCoverDW]
      ,[PATH_TemplateID]
      ,[PATH_LineNumber]
      ,[PATH_IsVisibleBRDID]
      ,[PATH_Name]
      ,[PATH_Description]
      ,[PATH_SubmitJScript]
      ,[PATH_AssignColName]
      ,[PATH_Assigments]
      ,[PATH_AssignDWColName]
      ,[PATH_AssigmentsDW]
      ,[PATH_RestrictedToUsers]
      ,[PATH_TaskName]
      ,[PATH_TaskDescription]
      ,[PATH_Guid]
      ,[PATH_ButtonStyle]
      ,[PATH_DocumentationDescription]
      ,[PATH_OnSubmitUxBRDID]
  FROM [BPS_Content].[dbo].[WFAvaiblePaths]

  select PATH_Name, PATH_IsDefault, PATH_ID, PATH_STPID,PATH_NextSTPId
  from WFAvaiblePaths