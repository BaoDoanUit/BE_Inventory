using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using MineralInventory.Respository;
using MineralInventory.Helper;
using MineralInventory.Models;
using MineralInventory;
using MineralInventory.Auth;

namespace MineralInventory.Services
{
    public class AdministratorService : Administrator.AdministratorBase
    {
        private readonly IJWTAuthenticationManager _jwtAuhthentic;
        public AdministratorService(IJWTAuthenticationManager jwtAuthentic)
        {
            _jwtAuhthentic = jwtAuthentic;
        }
        private Response response = new Response();


        public override Task<EquipmentResponse> GetListEquipment(MasterRequest request, ServerCallContext context)
        {
            var equipments = new EquipmentDAL().GetListEquipment();
            if (equipments == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(new EquipmentResponse()
                {
                    Response = response
                });
            }


            response.State = ResponseState.Success;
            response.Message = "";
            return Task.FromResult(new EquipmentResponse()
            {
                Data = { equipments },
                Response = response
            });
        }
        public override Task<PackingUnitResponse> GetListPackingUnit(MasterRequest request, ServerCallContext context)
        {
            var packingUnits = new PackingUnitDAL().GetListPackingUnit();
            if (packingUnits == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(new PackingUnitResponse()
                {
                    Response = response
                });
            }
            response.State = ResponseState.Success;
            response.Message = "";
            return Task.FromResult(new PackingUnitResponse()
            {
                Data = { packingUnits },
                Response = response
            });

        }
        public override Task<PartnerResponse> GetListPartner(MasterRequest request, ServerCallContext context)
        {
            var partners = new PartnerDAL().GetListPartner();
            if (partners == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(new PartnerResponse()
                {
                    Response = response
                });
            }

            response.State = ResponseState.Success;
            response.Message = "";
            return Task.FromResult(new PartnerResponse()
            {
                Data = { partners },
                Response = response
            });
        }
        public override Task<ReasonResponse> GetListReason(MasterRequest request, ServerCallContext context)
        {
            var reasons = new ReasonDAL().GetListReason();
            if (reasons == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(new ReasonResponse()
                {
                    Response = response
                });
            }


            response.State = ResponseState.Success;
            response.Message = "";
            return Task.FromResult(new ReasonResponse()
            {
                Data = { reasons },
                Response = response
            });
        }
        public override Task<ProductResponse> GetListProduct(MasterRequest request, ServerCallContext context)
        {
            var products = new ProductDAL().GetListProduct();
            if (products == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(new ProductResponse()
                {
                    Response = response
                });
            }

            response.State = ResponseState.Success;
            response.Message = "";
            return Task.FromResult(new ProductResponse()
            {
                Data = { products },
                Response = response
            });
        }
        public override Task<TypeBillResponse> GetListTypeBill(MasterRequest request, ServerCallContext context)
        {
            var typeBills = new TypeBillDAL().GetListTypeBill();
            if (typeBills == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(new TypeBillResponse()
                {
                    Response = response
                });
            }
            response.State = ResponseState.Success;
            response.Message = "";
            return Task.FromResult(new TypeBillResponse()
            {
                Data = { typeBills },
                Response = response
            });
        }
        public override Task<TypePacketResponse> GetListTypePacket(MasterRequest request, ServerCallContext context)
        {
            var typePackets = new TypePacketDAL().GetListTypePacket();
            if (typePackets == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(new TypePacketResponse()
                {
                    Response = response
                });
            }

            response.State = ResponseState.Success;
            response.Message = "";
            return Task.FromResult(new TypePacketResponse()
            {
                Data = { typePackets },
                Response = response
            });
        }
        public override Task<TypeProductResponse> GetListTypeProduct(MasterRequest request, ServerCallContext context)
        {
            var typeProducts = new TypeProductDAL().GetListTypeProduct();
            if (typeProducts == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(new TypeProductResponse()
                {
                    Response = response
                });
            }
            response.State = ResponseState.Success;
            response.Message = "";
            return Task.FromResult(new TypeProductResponse()
            {
                Data = { typeProducts },
                Response = response
            });
        }
        public override Task<WareHouseResponse> GetListWareHouse(MasterRequest request, ServerCallContext context)
        {
            var wareHouses = new WareHouseDAL().GetListWareHouse();
            if (wareHouses == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(new WareHouseResponse()
                {
                    Response = response
                });
            }

            response.State = ResponseState.Success;
            response.Message = "";
            return Task.FromResult(new WareHouseResponse()
            {
                Data = { wareHouses },
                Response = response
            });
        }
        public override Task<WorkResponse> GetListWork(MasterRequest request, ServerCallContext context)
        {
            var works = new WorkDAL().GetListWork();
            if (works == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(new WorkResponse()
                {
                    Response = response
                });
            }


            response.State = ResponseState.Success;
            response.Message = "";
            return Task.FromResult(new WorkResponse()
            {
                Data = { works },
                Response = response
            });
        }
        public override Task<MasterDataResponse> GetListTypeEquipment(MasterRequest request, ServerCallContext context)
        {
            var typeEquipments = new MasterDataDAL().GetMasterData();
            if (typeEquipments == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(new MasterDataResponse()
                {
                    Response = response
                });
            }

            response.State = ResponseState.Success;
            response.Message = "";
            return Task.FromResult(new MasterDataResponse()
            {
                Data = { typeEquipments },
                Response = response
            });
        }
        public override Task<MasterDataResponse> GetListMasterData(MasterRequest request, ServerCallContext context)
        {
            var typeEquipments = new MasterDataDAL().GetMasterData();
            if (typeEquipments == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(new MasterDataResponse()
                {
                    Response = response
                });
            }

            response.State = ResponseState.Success;
            response.Message = "";
            return Task.FromResult(new MasterDataResponse()
            {
                Data = { typeEquipments },
                Response = response
            });
        }
        public override Task<MasterDataResponse> GetListTypePartner(MasterRequest request, ServerCallContext context)
        {
            var typePartners = new MasterDataDAL().GetListTypePartner();
            if (typePartners == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(new MasterDataResponse()
                {
                    Response = response
                });
            }

            response.State = ResponseState.Success;
            response.Message = "";
            return Task.FromResult(new MasterDataResponse()
            {
                Data = { typePartners },
                Response = response
            });
        }
        public override Task<MasterDataResponse> GetListPosition(MasterRequest request, ServerCallContext context)
        {
            var positions = new MasterDataDAL().GetListPosition();
            if (positions == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(new MasterDataResponse()
                {
                    Response = response
                });
            }
            response.State = ResponseState.Success;
            response.Message = "";
            return Task.FromResult(new MasterDataResponse()
            {
                Data = { positions },
                Response = response
            });
        }



        //
        public override Task<Response> InsertEquipment(EquipmentInfo request, ServerCallContext context)
        {
            var equipments = new EquipmentDAL().GetListAllEquipment();
            request.CodeEquipment = request.CodeEquipment.Trim().ToUpper();
            var equipment =  equipments.Where(x => x.CodeEquipment.Trim() == request.CodeEquipment.Trim()).FirstOrDefault();  
            if (equipment != null )
            {
                if(equipment.IsDeleted)
                {
                    var res = new EquipmentDAL().SetDeleteEquipment(equipment.IdEquipment,false);
                    if(res)
                    {
                        response.State = ResponseState.Success;
                        response.Message = "Đã kích hoạt lại thiết bị";
                        return Task.FromResult(response);
                    }else
                    {
                        response.State = ResponseState.Fail;
                        response.Message = "Lỗi hệ thống";
                        return Task.FromResult(response);
                    }
                }
                response.State = ResponseState.Fail;
                response.Message = "Mã thiết bị đã tồn tại";
                return Task.FromResult(response);
            }

            if (new EquipmentDAL().InsertEquipment(request))
            {
                response.State = ResponseState.Success;
                response.Message = "Thành công";
            }
            else
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
            }
            return Task.FromResult(response);
        }

        public override Task<Response> UpdateEquipment(EquipmentInfo request, ServerCallContext context)
        {
            var equipments = new EquipmentDAL().GetListEquipment();
            if (equipments == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(response);
            }

            if (!equipments.Exists(x => x.IdEquipment == request.IdEquipment))
            {
                response.State = ResponseState.Fail;
                response.Message = "Không tồn tại";
                return Task.FromResult(response);
            }


            if (new EquipmentDAL().UpdateEquipment(request))
            {
                response.State = ResponseState.Success;
                response.Message = "Thành công";
            }
            else
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
            }
            return Task.FromResult(response);
        }
        public override Task<Response> DeleteEquipment(EquipmentInfo request, ServerCallContext context)
        {
            var equipments = new EquipmentDAL().GetListEquipment();
            if (equipments == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(response);
            }

            if (!equipments.Exists(x => x.IdEquipment == request.IdEquipment))
            {
                response.State = ResponseState.Fail;
                response.Message = "Không tồn tại";
                return Task.FromResult(response);
            }

            if (new EquipmentDAL().SetDeleteEquipment(request.IdEquipment,true))
            {
                response.State = ResponseState.Success;
                response.Message = "Thành công";
            }
            else
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
            }
            return Task.FromResult(response);
        }
        //
        public override Task<Response> InsertPackingUnit(PackingUnitInfo request, ServerCallContext context)
        {
            var packingUnits = new PackingUnitDAL().GetListAllPackingUnit();
            request.CodePackingUnit = request.CodePackingUnit.Trim().ToUpper();
            if (packingUnits == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(response);
            }
            var packingUnit = packingUnits.Where(x => x.CodePackingUnit.Trim() == request.CodePackingUnit.Trim()).FirstOrDefault();
            if (packingUnit != null)
            {   
                if(packingUnit.IsDeleted)
                {
                    var res = new PackingUnitDAL().SetDeletePackingUnit(packingUnit.IdPackingUnit,false);
                    if(res)
                    {
                        response.State = ResponseState.Success;
                        response.Message = "Đã kích hoạt lại đơn vị đóng";
                        return Task.FromResult(response);
                    }else
                    {
                        response.State = ResponseState.Fail;
                        response.Message = "Lỗi hệ thống";
                        return Task.FromResult(response);
                    }
                }
                
                response.State = ResponseState.Fail;
                response.Message = "Mã đã tồn tại trên hệ thống";
                return Task.FromResult(response);
            }

            if (new PackingUnitDAL().InsertPackingUnit(request))
            {
                response.State = ResponseState.Success;
                response.Message = "Thành công";
            }
            else
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
            }
            return Task.FromResult(response);
        }

        public override Task<Response> UpdatePackingUnit(PackingUnitInfo request, ServerCallContext context)
        {
            var packingUnits = new PackingUnitDAL().GetListPackingUnit();
            if (packingUnits == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(response);
            }
            if (!packingUnits.Exists(x => x.IdPackingUnit == request.IdPackingUnit))
            {
                response.State = ResponseState.Fail;
                response.Message = "Không tồn tại";
                return Task.FromResult(response);

            }


            if (new PackingUnitDAL().UpdatePackingUnit(request))
            {
                response.State = ResponseState.Success;
                response.Message = "Thành công";
            }
            else
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
            }
            return Task.FromResult(response);
        }
        public override Task<Response> DeletePackingUnit(PackingUnitInfo request, ServerCallContext context)
        {
            var packingUnits = new PackingUnitDAL().GetListPackingUnit();
            if (packingUnits == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(response);
            }

            if (!packingUnits.Exists(x => x.IdPackingUnit == request.IdPackingUnit))
            {
                response.State = ResponseState.Fail;
                response.Message = "Không tồn tại";
                return Task.FromResult(response);
            }

            if (new PackingUnitDAL().SetDeletePackingUnit(request.IdPackingUnit,true))
            {
                response.State = ResponseState.Success;
                response.Message = "Thành công";
            }
            else
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
            }
            return Task.FromResult(response);
        }

        //
        public override Task<Response> InsertPartner(PartnerInfo request, ServerCallContext context)
        {
            request.CodePartner = request.CodePartner.Trim().ToUpper();
            var partners = new PartnerDAL().GetListAllPartner();
            if (partners == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(response);
            }

            var partner = partners.Where(x => x.CodePartner.Trim() == request.CodePartner.Trim()).FirstOrDefault();
            if (partner != null)
            {
                if(partner.IsDeleted)
                {
                    var res = new PartnerDAL().SetDeletePartner(partner.IdPartner,false);
                    if(res)
                    {
                        response.State = ResponseState.Success;
                        response.Message = "Đã kích hoạt lại";
                        return Task.FromResult(response);
                    }else
                    {
                        response.State = ResponseState.Fail;
                        response.Message = "Lỗi hệ thống";
                        return Task.FromResult(response);
                    }
                }

                response.State = ResponseState.Fail;
                response.Message = "Mã đối tác đã tồn tại";
                return Task.FromResult(response);
            }

            if (new PartnerDAL().InsertPartner(request))
            {
                response.State = ResponseState.Success;
                response.Message = "Thành công";
            }
            else
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
            }
            return Task.FromResult(response);
        }

        public override Task<Response> UpdatePartner(PartnerInfo request, ServerCallContext context)
        {
            var partners = new PartnerDAL().GetListPartner();
            if (partners == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(response);
            }
            if (!partners.Exists(x => x.IdPartner == request.IdPartner))
            {
                response.State = ResponseState.Fail;
                response.Message = "Không tồn tại";
                return Task.FromResult(response);

            }

            if (new PartnerDAL().UpdatePartner(request))
            {
                response.State = ResponseState.Success;
                response.Message = "Thành công";
            }
            else
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
            }
            return Task.FromResult(response);
        }
        public override Task<Response> DeletePartner(PartnerInfo request, ServerCallContext context)
        {
            var partners = new PartnerDAL().GetListPartner();
            if (partners == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(response);
            }

            if (!partners.Exists(x => x.IdPartner == request.IdPartner))
            {
                response.State = ResponseState.Fail;
                response.Message = "Không tồn tại";
                return Task.FromResult(response);
            }

            if (new PartnerDAL().SetDeletePartner(request.IdPartner,true))
            {
                response.State = ResponseState.Success;
                response.Message = "Thành công";
            }
            else
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
            }
            return Task.FromResult(response);
        }

        //
        public override Task<Response> InsertProduct(ProductInfo request, ServerCallContext context)
        {
            if(string.IsNullOrWhiteSpace(request.NameProduct)|| request.Weight<= 0)
            {
                response.State = ResponseState.Fail;
                response.Message = "Thông tin không hợp lệ";
                return Task.FromResult(response);
            }

            var products = new ProductDAL().GetListAllProduct();
            if (products == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(response);
            }
            
            var product  = products.Where(x => x.CodeProduct == request.CodeProduct).FirstOrDefault();
            if (product != null)
            {

                if(product.IsDeleted == false)
                {
                    response.State = ResponseState.Fail;
                    response.Message = "Mã sản phẩm đã tồn tại";
                    return Task.FromResult(response);
                }

                var res = new ProductDAL().SetDeleteProduct(product.IdProduct,false);
                if(res)
                {
                    response.State = ResponseState.Success;
                    response.Message = "Sản phẩm đã được kích hoạt lại";
                    return Task.FromResult(response);
                }else
                {
                    response.State = ResponseState.Fail;
                    response.Message = "lỗi hệ thống";
                    return Task.FromResult(response);
                }
                
            }

            


            if (new ProductDAL().InsertProduct(request))
            {
                response.State = ResponseState.Success;
                response.Message = "Thành công";
            }
            else
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
            }
            return Task.FromResult(response);
        }

        public override Task<Response> UpdateProduct(ProductInfo request, ServerCallContext context)
        {
            var products = new ProductDAL().GetListProduct();
            if (products == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(response);
            }

            if (!products.Exists(x => x.IdProduct == request.IdProduct))
            {
                response.State = ResponseState.Fail;
                response.Message = "Không tồn tại";
                return Task.FromResult(response);

            }


            if (new ProductDAL().UpdateProduct(request))
            {
                response.State = ResponseState.Success;
                response.Message = "Thành công";
            }
            else
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
            }
            return Task.FromResult(response);
        }
        public override Task<Response> DeleteProduct(ProductInfo request, ServerCallContext context)
        {
            var products = new ProductDAL().GetListProduct();
            if (products == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(response);
            }

            if (!products.Exists(x => x.IdProduct == request.IdProduct))
            {
                response.State = ResponseState.Fail;
                response.Message = "Không tồn tại";
                return Task.FromResult(response);
            }

            if (new ProductDAL().SetDeleteProduct(request.IdProduct,true))
            {
                response.State = ResponseState.Success;
                response.Message = "Thành công";
            }
            else
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
            }
            return Task.FromResult(response);
        }
        //
        public override Task<Response> InsertReason(ReasonInfo request, ServerCallContext context)
        {

            var reasons = new ReasonDAL().GetListAllReason();
            request.CodeReason = request.CodeReason.Trim().ToUpper();
            if (reasons == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(response);
            }
            var reason = reasons.Where(x => x.CodeReason.Trim() == request.CodeReason.Trim()).FirstOrDefault();
            if (reason!= null)
            {
                if(reason.IsDeleted)
                {
                    var res = new ReasonDAL().SetDeleteReason(reason.IdReason,false);
                    if(res)
                    {
                        response.State = ResponseState.Success;
                        response.Message = "Đã kích hoạt lại nguyên nhân";
                        return Task.FromResult(response);
                    }else
                    {
                        response.State = ResponseState.Fail;
                        response.Message = "Lỗi hệ thống";
                        return Task.FromResult(response);
                    }
                }
                response.State = ResponseState.Fail;
                response.Message = "Mã nguyên nhân đã tồn tại";
                return Task.FromResult(response);
            }

            if (new ReasonDAL().InsertReason(request))
            {
                response.State = ResponseState.Success;
                response.Message = "Thành công";
            }
            else
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
            }
            return Task.FromResult(response);
        }

        public override Task<Response> UpdateReason(ReasonInfo request, ServerCallContext context)
        {
            var reasons = new ReasonDAL().GetListReason();
            if (reasons == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(response);
            }
            if (!reasons.Exists(x => x.IdReason == request.IdReason))
            {
                response.State = ResponseState.Fail;
                response.Message = "Không tồn tại";
                return Task.FromResult(response);

            }

            if (new ReasonDAL().UpdateReason(request))
            {
                response.State = ResponseState.Success;
                response.Message = "Thành công";
            }
            else
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
            }
            return Task.FromResult(response);
        }
        public override Task<Response> DeleteReason(ReasonInfo request, ServerCallContext context)
        {
            var reasons = new ReasonDAL().GetListReason();
            if (!reasons.Exists(x => x.IdReason == request.IdReason))
            {
                response.State = ResponseState.Fail;
                response.Message = "Không tồn tại";
                return Task.FromResult(response);
            }

            if (new ReasonDAL().SetDeleteReason(request.IdReason,true))
            {
                response.State = ResponseState.Success;
                response.Message = "Thành công";
            }
            else
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
            }
            return Task.FromResult(response);
        }

        //
        public override Task<Response> InsertTypeBill(TypeBillInfo request, ServerCallContext context)
        {

            var typeBills = new TypeBillDAL().GetListAllTypeBill();
            request.CodeTypeBill = request.CodeTypeBill.Trim().ToUpper();

            var typeBill = typeBills.Where(x => x.CodeTypeBill.Trim() == request.CodeTypeBill.Trim()).FirstOrDefault();
            if (typeBill != null)
            {
                if(typeBill.IsDeleted)
                {
                    var res = new TypeBillDAL().SetDeleteTypeBill(typeBill.IdTypeBill,false);
                    if(res)
                    {
                        response.State = ResponseState.Success;
                        response.Message = "Đã kích hoạt lại";
                        return Task.FromResult(response);
                    }else
                    {
                        response.State = ResponseState.Fail;
                        response.Message = "Lỗi hệ thống";
                        return Task.FromResult(response);
                    }
                }
                response.State = ResponseState.Fail;
                response.Message = "Mã phiếu đã tồn tại";
                return Task.FromResult(response);
            }


            if (new TypeBillDAL().InsertTypeBill(request))
            {
                response.State = ResponseState.Success;
                response.Message = "Thành công";
            }
            else
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
            }
            return Task.FromResult(response);
        }

        public override Task<Response> UpdateTypeBill(TypeBillInfo request, ServerCallContext context)
        {
            var typeBills = new TypeBillDAL().GetListTypeBill();
            if (typeBills == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(response);
            }
            if (!typeBills.Exists(x => x.IdTypeBill == request.IdTypeBill))
            {
                response.State = ResponseState.Fail;
                response.Message = "Không tồn tại";
                return Task.FromResult(response);

            }
            var typeBill = new TypeBillInfo()
            {
                NameTypeBill = request.NameTypeBill.Trim(),
                IdTypeBill = request.IdTypeBill,
            };

            if (new TypeBillDAL().UpdateTypeBill(typeBill))
            {
                response.State = ResponseState.Success;
                response.Message = "Thành công";
            }
            else
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
            }
            return Task.FromResult(response);
        }
        public override Task<Response> DeleteTypeBill(TypeBillInfo request, ServerCallContext context)
        {
            var typeBills = new TypeBillDAL().GetListTypeBill();
            if (typeBills == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(response);
            }
            
            if (!typeBills.Exists(x => x.IdTypeBill == request.IdTypeBill))
            {
                response.State = ResponseState.Fail;
                response.Message = "Không tồn tại";
                return Task.FromResult(response);
            }

            if (new TypeBillDAL().SetDeleteTypeBill(request.IdTypeBill,true))
            {
                response.State = ResponseState.Success;
                response.Message = "Thành công";
            }
            else
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
            }
            return Task.FromResult(response);
        }

        //
        public override Task<Response> InsertTypePacket(TypePacketInfo request, ServerCallContext context)
        {
            var typePackets = new TypePacketDAL().GetListAllTypePacket();
            request.CodeTypePacket = request.CodeTypePacket.Trim().ToUpper();
            if (typePackets == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(response);
            }

            var typePacket = typePackets.Where(x => x.CodeTypePacket.Trim() == request.CodeTypePacket.Trim()).FirstOrDefault();
            if (typePacket != null)
            {
                if(typePacket.IsDeleted)
                {
                    var res = new TypePacketDAL().SetDeleteTypePacket(typePacket.IdTypePacket,false);
                    if(res)
                    {
                        response.State = ResponseState.Success;
                        response.Message = "Đã kích hoạt lại";
                        return Task.FromResult(response);
                    }else
                    {
                        response.State = ResponseState.Fail;
                        response.Message = "Lỗi hệ thống";
                        return Task.FromResult(response);
                    }
                }
                response.State = ResponseState.Fail;
                response.Message = "Mã loại bao tồn tại";
                return Task.FromResult(response);
            }

            

            if (new TypePacketDAL().InsertTypePacket(request))
            {
                response.State = ResponseState.Success;
                response.Message = "Thành công";
            }
            else
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
            }
            return Task.FromResult(response);
        }

        public override Task<Response> UpdateTypePacket(TypePacketInfo request, ServerCallContext context)
        {
            var typePackets = new TypePacketDAL().GetListTypePacket();
            if (typePackets == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(response);
            }

            if (!typePackets.Exists(x => x.IdTypePacket == request.IdTypePacket))
            {
                response.State = ResponseState.Fail;
                response.Message = "Không tồn tại";
                return Task.FromResult(response);

            }


            if (new TypePacketDAL().UpdateTypePacket(request))
            {
                response.State = ResponseState.Success;
                response.Message = "Thành công";
            }
            else
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
            }
            return Task.FromResult(response);
        }
        public override Task<Response> DeleteTypePacket(TypePacketInfo request, ServerCallContext context)
        {
            var typePackets = new TypePacketDAL().GetListTypePacket();
            if (typePackets == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(response);
            }
            if (!typePackets.Exists(x => x.IdTypePacket == request.IdTypePacket))
            {
                response.State = ResponseState.Fail;
                response.Message = "Không tồn tại";
                return Task.FromResult(response);
            }

            if (new TypePacketDAL().SetDeleteTypePacket(request.IdTypePacket,true))
            {
                response.State = ResponseState.Success;
                response.Message = "Thành công";
            }
            else
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
            }
            return Task.FromResult(response);
        }

        //
        public override Task<Response> InsertTypeProduct(TypeProductInfo request, ServerCallContext context)
        {

            var typeProducts = new TypeProductDAL().GetListAllTypeProduct();
            var type = typeProducts.Where(x => x.IdTypeProduct == request.IdTypeProduct).FirstOrDefault();
            if (type != null)
            {
                if(type.IsDeleted)
                {
                    if (new TypeProductDAL().SetDeleteTypeProduct(request.IdTypeProduct, false))
                    {
                        response.State = ResponseState.Success;
                        response.Message = "Đã khôi phục loại sản phẩm";
                    }
                    else
                    {
                        response.State = ResponseState.Fail;
                        response.Message = "Lỗi hệ thống";
                    }
                    return Task.FromResult(response);
                }

                response.State = ResponseState.Fail;
                response.Message = "Loại sản phẩm đã tồn tại";
                return Task.FromResult(response);

            }    

            if (new TypeProductDAL().InsertTypeProduct(request))
            {
                response.State = ResponseState.Success;
                response.Message = "Thành công";
            }
            else
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
            }
            return Task.FromResult(response);
        }

        
        public override Task<Response> DeleteTypeProduct(TypeProductInfo request, ServerCallContext context)
        {
            var typeProducts = new TypeProductDAL().GetListTypeProduct();
            if (typeProducts == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(response);
            }
            if (!typeProducts.Exists(x => x.IdTypeProduct == request.IdTypeProduct))
            {
                response.State = ResponseState.Fail;
                response.Message = "Không tồn tại";
                return Task.FromResult(response);
            }

            if (new TypeProductDAL().SetDeleteTypeProduct(request.IdTypeProduct,true))
            {
                response.State = ResponseState.Success;
                response.Message = "Thành công";
            }
            else
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
            }
            return Task.FromResult(response);
        }
        //
        public override Task<Response> InsertWareHouse(WareHouseInfo request, ServerCallContext context)
        {

            var wareHouses = new WareHouseDAL().GetListAllWareHouse();
            request.CodeWareHouse = request.CodeWareHouse.Trim().ToUpper();
            if (wareHouses == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(response);
            }


            var wareHouse = wareHouses.Where(x => x.CodeWareHouse.Trim() == request.CodeWareHouse.Trim()).FirstOrDefault();
            if (wareHouse != null)
            {
                if(wareHouse.IsDeleted)
                {
                    var res = new WareHouseDAL().SetDeleteWareHouse(wareHouse.IdWareHouse,false);
                    if(res)
                    {
                        response.State = ResponseState.Success;
                        response.Message = "Đã kích hoạt lại";
                        return Task.FromResult(response);
                    }else
                    {
                        response.State = ResponseState.Fail;
                        response.Message = "Lỗi hệ thống";
                        return Task.FromResult(response);
                    }
                }
                response.State = ResponseState.Fail;
                response.Message = "Mã kho đã tồn tại";
                return Task.FromResult(response);
            }


            if (new WareHouseDAL().InsertWareHouse(request))
            {
                response.State = ResponseState.Success;
                response.Message = "Thành công";
            }
            else
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
            }
            return Task.FromResult(response);
        }

        public override Task<Response> UpdateWareHouse(WareHouseInfo request, ServerCallContext context)
        {
            var wareHouses = new WareHouseDAL().GetListWareHouse();
            if (wareHouses == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(response);
            }

            if (!wareHouses.Exists(x => x.IdWareHouse == request.IdWareHouse))
            {
                response.State = ResponseState.Fail;
                response.Message = "Không tồn tại";
                return Task.FromResult(response);

            }


            if (new WareHouseDAL().UpdateWareHouse(request))
            {
                response.State = ResponseState.Success;
                response.Message = "Thành công";
            }
            else
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
            }
            return Task.FromResult(response);
        }
        public override Task<Response> DeleteWareHouse(WareHouseInfo request, ServerCallContext context)
        {
            var wareHouses = new WareHouseDAL().GetListWareHouse();
            if (wareHouses == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(response);
            }

            if (!wareHouses.Exists(x => x.IdWareHouse == request.IdWareHouse))
            {
                response.State = ResponseState.Fail;
                response.Message = "Không tồn tại";
                return Task.FromResult(response);
            }

            if (new WareHouseDAL().SetDeleteWareHouse(request.IdWareHouse,true))
            {
                response.State = ResponseState.Success;
                response.Message = "Thành công";
            }
            else
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
            }
            return Task.FromResult(response);
        }
        //

        //
        public override Task<Response> InsertWork(WorkInfo request, ServerCallContext context)
        {

            var works = new WorkDAL().GetListAllWork();
            request.CodeWork = request.CodeWork.Trim().ToUpper();
            if (works == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(response);
            }
            var work = works.Where(x => x.CodeWork == request.CodeWork).FirstOrDefault();
            if (work != null)
            {
                if(work.IsDeleted)
                {
                    var res = new WorkDAL().SetDeleteWork(work.IdWork,false);
                    if(res)
                    {
                        response.State = ResponseState.Success;
                        response.Message = "Đã kích hoạt lại";
                        return Task.FromResult(response);
                    }else
                    {
                        response.State = ResponseState.Fail;
                        response.Message = "Lỗi hệ thống";
                        return Task.FromResult(response);
                    }
                }
                response.State = ResponseState.Fail;
                response.Message = "Mã công việc đã tồn tại";
                return Task.FromResult(response);
            }


            if (new WorkDAL().InsertWork(request))
            {
                response.State = ResponseState.Success;
                response.Message = "Thành công";
            }
            else
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
            }
            return Task.FromResult(response);
        }

        public override Task<Response> UpdateWork(WorkInfo request, ServerCallContext context)
        {
            var work = new WorkDAL().GetListWork();
            if (work == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(response);
            }

            if (!work.Exists(x => x.IdWork == request.IdWork))
            {
                response.State = ResponseState.Fail;
                response.Message = "Không tồn tại";
                return Task.FromResult(response);

            }

            if (new WorkDAL().UpdateWork(request))
            {
                response.State = ResponseState.Success;
                response.Message = "Thành công";
            }
            else
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
            }
            return Task.FromResult(response);
        }
        public override Task<Response> DeleteWork(WorkInfo request, ServerCallContext context)
        {
            var works = new WorkDAL().GetListWork();
            if (works == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(response);
            }
            if (!works.Exists(x => x.IdWork == request.IdWork))
            {
                response.State = ResponseState.Fail;
                response.Message = "Không tồn tại";
                return Task.FromResult(response);
            }

            if (new WorkDAL().SetDeleteWork(request.IdWork,true))
            {
                response.State = ResponseState.Success;
                response.Message = "Thành công";
            }
            else
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
            }
            return Task.FromResult(response);
        }
        //

        public override Task<Response> InsertDevice(DeviceInfo request, ServerCallContext context)
        {
            var listDeivce = new DeviceDAL().GetListDevice();
            if (listDeivce == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(response);
            }

            if (listDeivce.Exists(x => x.Device.Trim() == request.Device.Trim()))
            {
                response.State = ResponseState.Fail;
                response.Message = "Device đã tồn tại";
                return Task.FromResult(response);
            }

            if (new DeviceDAL().InsertDevice(request))
            {
                response.State = ResponseState.Success;
                response.Message = "Thành công";
            }
            else
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
            }
            return Task.FromResult(response);
        }
        public override Task<DeviceResponse> GetListDevices(MasterRequest request, ServerCallContext context)
        {
            var devices = new DeviceDAL().GetListDevice();

            if (devices == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(new DeviceResponse()
                {
                    Response = response
                });
            }

            response.State = ResponseState.Success;
            response.Message = "";
            return Task.FromResult(new DeviceResponse()
            {
                Data = { devices },
                Response = response
            });
        }
        public override Task<Response> UpdateDevice(DeviceInfo request, ServerCallContext context)
        {
            var listDeivce = new DeviceDAL().GetListDevice();
            if (listDeivce == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(response);
            }

            if (!listDeivce.Exists(x => x.ID == request.ID))
            {
                response.State = ResponseState.Fail;
                response.Message = "Không tồn tại";
                return Task.FromResult(response);
            }


            if (new DeviceDAL().UpdateDevice(request))
            {
                response.State = ResponseState.Success;
                response.Message = "Thành công";
            }
            else
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
            }
            return Task.FromResult(response);
        }
        public override Task<Response> DeleteDevice(DeviceInfo request, ServerCallContext context)
        {
            var listDeivce = new DeviceDAL().GetListDevice();
            if (listDeivce == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(response);
            }

            if (!listDeivce.Exists(x => x.ID == request.ID))
            {
                response.State = ResponseState.Fail;
                response.Message = "Không tồn tại";
                return Task.FromResult(response);
            }

            if (new DeviceDAL().DeleteDevice(request.ID))
            {
                response.State = ResponseState.Success;
                response.Message = "Thành công";
            }
            else
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
            }
            return Task.FromResult(response);
        }



        public override Task<UserResponse> GetListUsers(MasterRequest request, ServerCallContext context)
        {
            var users = new UserDAL().GetListUser();
            if (users == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(new UserResponse()
                {
                    Response = response
                });
            }
            response.State = ResponseState.Success;
            response.Message = "";
            return Task.FromResult(new UserResponse()
            {
                Users = { users },
                Response = response
            });
        }

      
      


        public override Task<Response> DeleteRecordObject(RecordObjectInfo request, ServerCallContext context)
        {

            var listPeople = new RecordObjectDAL().GetListObejct();
            if (listPeople == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(response);
            }


            if (!listPeople.Exists(x => x.IdObject == request.IdObject))
            {
                response.State = ResponseState.Fail;
                response.Message = "Không tồn tại ";
                return Task.FromResult(response);
            }

            var res = new RecordObjectDAL().DeleteObject(request);
            if (res)
            {
                response.State = ResponseState.Success;
                response.Message = "Thành công";
            }
            else
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
            }
            return Task.FromResult(response);
        }
        public override Task<Response> InsertRecordObject(RecordObjectInfo request, ServerCallContext context)
        {
            request.NameObject = request.NameObject.Trim();



            var res = new RecordObjectDAL().InsertObject(request);
            if (res)
            {
                response.State = ResponseState.Success;
                response.Message = "Thành công";
            }
            else
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
            }
            return Task.FromResult(response);
        }
        public override Task<Response> UpdateRecordObject(RecordObjectInfo request, ServerCallContext context)
        {
            var listPeople = new RecordObjectDAL().GetListObejct();
            if (listPeople == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(response);
            }


            if (!listPeople.Exists(x => x.IdObject == request.IdObject))
            {
                response.State = ResponseState.Fail;
                response.Message = "Không tồn tại ";
                return Task.FromResult(response);
            }

            var res = new RecordObjectDAL().UpdateObject(request);
            if (res)
            {
                response.State = ResponseState.Success;
                response.Message = "Thành công";
            }
            else
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
            }
            return Task.FromResult(response);
        }

        public override Task<RecordObjectResponse> GetListRecordObject(MasterRequest request, ServerCallContext context)
        {
            var listPeople = new RecordObjectDAL().GetListObejct();
            if (listPeople == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult<RecordObjectResponse>(new RecordObjectResponse()
                {
                    Response = response
                });
            }

            response.State = ResponseState.Success;
            response.Message = "";
            return Task.FromResult<RecordObjectResponse>(new RecordObjectResponse()
            {
                Data = { listPeople },
                Response = response
            });
        }
        public override Task<TransportationUnitResponse> GetListTransportationUnit(MasterRequest request, ServerCallContext context)
        {
            var transportationUnits = new TransportationUnitDAL().GetListTransportationUnit();
            if (transportationUnits == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult<TransportationUnitResponse>(new TransportationUnitResponse()
                {
                    Response = response
                });
            }

            response.State = ResponseState.Success;
            response.Message = "";
            return Task.FromResult<TransportationUnitResponse>(new TransportationUnitResponse()
            {
                Data = { transportationUnits },
                Response = response
            });
        }
        public override Task<MasterDataResponse> GetListMaster(MasterDataInfo request, ServerCallContext context)
        {
            var masters = new MasterDAL().GetListMaster().Where(x => x.IsDeleted == false);
            if (masters == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult<MasterDataResponse>(new MasterDataResponse()
                {
                    Response = response
                });
            }

            response.State = ResponseState.Success;
            response.Message = "";
            return Task.FromResult<MasterDataResponse>(new MasterDataResponse()
            {
                Data = { masters },
                Response = response
            });
        }
        public override Task<Response> InsertMaster(MasterDataInfo request, ServerCallContext context)
        {
            request.ObjectCode = request.ObjectCode.Trim().ToUpper();
            request.ObjectCate = request.ObjectCate.Trim().ToUpper();
            request.ObjectType = request.ObjectType.Trim().ToUpper();

            if (string.IsNullOrWhiteSpace(request.ObjectName) || 
            string.IsNullOrWhiteSpace(request.ObjectType)
            )
            {
                response.State = ResponseState.Fail;
                response.Message = "Thiếu thông tin";
                return Task.FromResult(response);
            }

            var typeMaster = new MasterDAL().GetListTypeMaster();
            if(!typeMaster.Exists(x => x.ObjectCode == request.ObjectType.Trim().ToUpper()))
            {
                response.State = ResponseState.Fail;
                response.Message = "Object type không đúng";
                return Task.FromResult(response);
            }
            if(request.ObjectType == "PARTNER")
            {
                 if(!typeMaster.Exists(x => x.ObjectCode == request.ObjectCate.Trim().ToUpper()))
                    {
                        response.State = ResponseState.Fail;
                        response.Message = "Object cate không đúng";
                        return Task.FromResult(response);
                    }
            }else
                request.ObjectCate = "";

            bool res;
            var masters = new MasterDAL().GetListMaster();
            var master = masters.Where(x => x.ObjectCode == request.ObjectCode && x.ObjectType == request.ObjectType).FirstOrDefault();
            if(master != null)
            {
               
                if(master.IsDeleted)
                {
                    res =new MasterDAL().SetDeleteMaster(master.ObjectId,false);
                    if(res)
                    {
                        response.State = ResponseState.Success;
                        response.Message = "Mã đã được khôi phục";
                        return Task.FromResult(response);
                    }else
                    {
                        response.State = ResponseState.Success;
                        response.Message = "Lỗi hệ thống";
                        return Task.FromResult(response);
                    }
                    
                }else
                {
                    response.State = ResponseState.Fail;
                    response.Message = "Đã tồn tại trên hệ thống";
                    return Task.FromResult(response);
                }
            }

            res = new MasterDAL().InsertMaster(request);
            if (res)
            {
                response.State = ResponseState.Success;
                response.Message = "Thành công";
            }
            else
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
            }
            return Task.FromResult(response);
        }
        public override Task<Response> UpdateMaster(MasterDataInfo request, ServerCallContext context)
        {
            if(string.IsNullOrWhiteSpace(request.ObjectName))
            {
                response.State = ResponseState.Fail;
                response.Message = "Thiếu thông tin";
                return Task.FromResult(response);
            }
           
            bool res;
            var masters = new MasterDAL().GetListMaster();
            var master = masters.Where(x => x.ObjectId == request.ObjectId && x.IsDeleted == false).FirstOrDefault();
            if(master == null)
            {         
                response.State = ResponseState.Fail;
                response.Message = "Không tồn tại trên hệ thống";
                return Task.FromResult(response);
            }

             
            var typeMaster = new MasterDAL().GetListTypeMaster();
            if(request.ObjectType == "PARTNER")
            {
                 if(!typeMaster.Exists(x => x.ObjectCode == request.ObjectCate.Trim().ToUpper()))
                    {
                        response.State = ResponseState.Fail;
                        response.Message = "Object cate không đúng";
                        return Task.FromResult(response);
                    }
            }else
                request.ObjectCate = "";

            res = new MasterDAL().UpdateMaster(request);
            if (res)
            {
                response.State = ResponseState.Success;
                response.Message = "Thành công";
            }
            else
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
            }
            return Task.FromResult(response);
        }
        public override Task<Response> SetDeletedMaster(MasterDataInfo request, ServerCallContext context)
        {
           
           
            bool res;
            var masters = new MasterDAL().GetListMaster();
            var master = masters.Where(x => x.ObjectId == request.ObjectId && x.IsDeleted == false).FirstOrDefault();
            if(master == null)
            {         
                response.State = ResponseState.Fail;
                response.Message = "Không tồn tại trên hệ thống";
                return Task.FromResult(response);
            }
            res = new MasterDAL().SetDeleteMaster(request.ObjectId,true);
            if (res)
            {
                response.State = ResponseState.Success;
                response.Message = "Xóa thành công";
            }
            else
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
            }
            return Task.FromResult(response);
        }

    }
}