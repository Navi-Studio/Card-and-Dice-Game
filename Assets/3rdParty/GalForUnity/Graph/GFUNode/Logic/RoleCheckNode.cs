﻿//======================================================================
//
//       CopyRight 2019-2021 © MUXI Game Studio 
//       . All Rights Reserved 
//
//        FileName :  RoleCheckNode.cs
//
//        Created by #AuthorName# at #CreateTime#
//
//======================================================================

using GalForUnity.Attributes;
using GalForUnity.Graph.Attributes;
using GalForUnity.Graph.Data;
using GalForUnity.Graph.GFUNode.Base;
using GalForUnity.Model;

namespace GalForUnity.Graph.GFUNode.Logic{
    [NodeRename("Logic/" + nameof(RoleCheckNode), "角色检查节点，该节点负责检查在图中流转的角色是否满足要求，如果要求达到，则会跳转满足出口，否则则会跳转不满足出口")]
    // [NodeFieldType(typeof(RoleModel), "roleModel")]
    [NodeAttributeUsage(NodeAttributeTargets.FlowGraph)]
    public class RoleCheckNode : ObjectFieldNode<RoleModel>{
        [NodeRename("Satisfy" + nameof(Exit), typeof(RoleData), NodeDirection.Output, NodeCapacity.Single)]
        public GfuPort Exit;

        [NodeRename(nameof(DissatisfyExit), typeof(RoleData), NodeDirection.Output, NodeCapacity.Single)]
        public GfuPort DissatisfyExit;

        /// <summary>
        /// 因为继承自父类的Save方法反射保存了遍历和初始化了变量，所有Init似乎也就不被需要了？，如果要定义多个变量还是需要的
        /// </summary>
        /// <param name="otherNodeData"></param>
        public override void Init(NodeData otherNodeData){
            base.Init(otherNodeData);
            // RegisterValueChangedCallback(this);
        }

        public override RoleData Execute(RoleData roleData){
            if (objectReference){
                if (objectReference == roleData.RoleModel){
                    return base.Execute(roleData); //如果角色数据要求满足，那么走满足的节点
                }
            } else{
                return base.Execute(roleData); //如果角色要求为空的话，那么默认就是不对角色数值做要求，一律满足
            }

            return Executed(1, roleData);
        }
    }
}
